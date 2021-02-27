using OrderManagement.Backend;
using OrderManagement.Backend.DataModels;
using OrderManagement.Client.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Generic;

namespace OrderManagement.Client
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Address> GridListAddress = new ObservableCollection<Address>();
        public ObservableCollection<Customer> GridListCustomer = new ObservableCollection<Customer>();
        private IActivePage _page;

        public MainWindow()
        {
            InitializeComponent();

            // default page
            _page = GetActivePage<Address>();
            OnSwitchView();
        }

        private void OnSwitchView(object sender = null, MouseButtonEventArgs e = null)
        {
            dynamic obj = sender;
            Header.Content = obj?.Name?.ToString() ?? "Address";
            
            if (Header.Content.ToString() == "Customer")
                SetActivePage<Customer>();
            if (Header.Content.ToString() == "Address")
                SetActivePage<Address>();
            if (Header.Content.ToString() == "Product")
                SetActivePage<Product>();
            if (Header.Content.ToString() == "ProductGroup")
                SetActivePage<ProductGroup>();
            if (Header.Content.ToString() == "Order")
                SetActivePage<Order>();
            if (Header.Content.ToString() == "OrderPosition")
                SetActivePage<OrderPosition>();
            if (Header.Content.ToString() == "ProductTree")
                SetTreePageActive();
        }

        private void SetTreePageActive()
        {
            GenericGrid.Visibility = Visibility.Hidden;
            GenericTree.Visibility = Visibility.Visible;
            _page = new ActivePage<ProductGroup>(RepositoryCollection.Instance.ProductTreeRepository, true);
            GenericTree.Items.Add(RepositoryCollection.Instance.ProductTreeRepository.Get(1));
        }

        private void SetActivePage<T>() where T : IHasId
        {
            GenericGrid.Visibility = Visibility.Visible;
            GenericTree.Visibility = Visibility.Hidden;
            _page = GetActivePage(typeof(T));
            GenericGrid.DataContext = GetActivePage<T>().ObservableCollection;
        }

        private ActivePage<T> GetActivePage<T>() where T : IHasId => _page as ActivePage<T>;
        
        private IActivePage GetActivePage(Type t)
        {
            if (t == typeof(Customer))
                return new ActivePage<Customer>(RepositoryCollection.Instance.CustomerRepository);
            if (t == typeof(Product))
                return new ActivePage<Product>(RepositoryCollection.Instance.ProductRepository);
            if (t == typeof(ProductGroup))
                return new ActivePage<ProductGroup>(RepositoryCollection.Instance.ProductGroupRepository);
            if (t == typeof(Order))
                return new ActivePage<Order>(RepositoryCollection.Instance.OrderRepository);
            if (t == typeof(OrderPosition))
                return new ActivePage<OrderPosition>(RepositoryCollection.Instance.OrderPositionRepository);
            if (t == typeof(Address))
                return new ActivePage<Address>(RepositoryCollection.Instance.AddressRepository);
            throw new Exception();
        }

        private void RowEdited(object sender, DataGridRowEditEndingEventArgs e)
        {
            switch (Header.Content)
            {
                case "Address":
                    // Validate address here.
                    e.Row.Item = UpdateOrInsert<Address>(e.Row.Item);
                    break;
                case "Customer":
                    // Validate customer here.
                    e.Row.Item = UpdateOrInsert<Customer>(e.Row.Item);
                    break;
                case "Order":
                    // Validate order here.
                    e.Row.Item = UpdateOrInsert<Order>(e.Row.Item);
                    break;
                case "OrderPosition":
                    // Validate order position here.
                    e.Row.Item = UpdateOrInsert<OrderPosition>(e.Row.Item);
                    break;
                case "Product":
                    // Validate product here.
                    e.Row.Item = UpdateOrInsert<Product>(e.Row.Item);
                    break;
                case "ProductGroup":
                    // Validate product group here.
                    e.Row.Item = UpdateOrInsert<ProductGroup>(e.Row.Item);
                    break;
            }
        }

        private T UpdateOrInsert<T>(object rowItem) where T : IHasId
        {
            var item = (T)rowItem;
            var repository = GetActivePage<T>().Repository;
            if (item.Id == 0)
                item = repository.Add(item);
            else
                item = repository.Update(item);
            return item;
        }

        private void GenericGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var tc = e.Column as DataGridTextColumn;
            var b = tc.Binding as Binding;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            if ((!e.PropertyType.IsValueType && e.PropertyType != typeof(string)) || e.PropertyName.ToLower() == "id")
            {
                e.Column.IsReadOnly = true;
            }
        }

        private void DeleteClicked(object sender, RoutedEventArgs e)
        {
            var page = GetActivePage(_page.Type);

            if (page.Type == typeof(Customer))
                Delete<Customer>(page);
            if (page.Type == typeof(Address))
                Delete<Address>(page);
            if (page.Type == typeof(Order))
                Delete<Order>(page);
            if (page.Type == typeof(OrderPosition))
                Delete<OrderPosition>(page);
            if (page.Type == typeof(Product))
                Delete<Product>(page);
            if (page.Type == typeof(ProductGroup))
                Delete<ProductGroup>(page);
        }

        private void Delete<T>(IActivePage page) where T : IHasId
        {
            var convertedPage = (ActivePage<T>)Convert.ChangeType(page, typeof(ActivePage<T>));
            var deleteId = ((T)GenericGrid.SelectedItem).Id;
            convertedPage.Repository.Delete(deleteId);
            GenericGrid.DataContext = GetActivePage<T>().ObservableCollection;
        }
    }
}
