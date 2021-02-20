using OrderManagement.Backend;
using OrderManagement.Backend.DataModels;
using OrderManagement.Client.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
<<<<<<< HEAD
using System.Globalization;
using System.Linq;
=======
>>>>>>> main
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
<<<<<<< HEAD
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.DataModels;
=======
>>>>>>> main

namespace OrderManagement.Client
{
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
        private Backend.RepositoryCollection context = new Backend.RepositoryCollection();
=======
        public ObservableCollection<Address> GridListAddress = new ObservableCollection<Address>();
        public ObservableCollection<Customer> GridListCustomer = new ObservableCollection<Customer>();
        private IActivePage _page;
>>>>>>> main

        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
        }

        private void ResetIcoColor()
        {
            CustomerIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            AddrIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleGrpIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            OrdersIco.Foreground = new SolidColorBrush(Colors.LightBlue);
        }

        private void CustomerIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetIcoColor();
            CustomerIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.Blue, 90);

            ObservableCollection<Backend.DataModels.Customer> GridList = new ObservableCollection<Backend.DataModels.Customer>();
            var entries = context.CustomerRepository.Get();
            foreach (var entry in entries)
            {
                GridList.Add(entry);
            }
            GenericGrid.DataContext = GridList;
        }

        private void ArticleGrpIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetIcoColor();
            ArticleGrpIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.Blue, 90);

            ObservableCollection<Backend.DataModels.ProductGroup> GridList = new ObservableCollection<Backend.DataModels.ProductGroup>();
            var entries = context.ProductGroupRepository.Get();
            foreach (var entry in entries)
            {
                GridList.Add(entry);
            }
            GenericGrid.DataContext = GridList;
        }

        private void ArticleIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetIcoColor();
            ArticleIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.Blue, 90);

            ObservableCollection<Backend.DataModels.Product> GridList = new ObservableCollection<Backend.DataModels.Product>();
            var entries = context.ProductRepository.Get();
            foreach (var entry in entries)
            {
                GridList.Add(entry);
            }
            GenericGrid.DataContext = GridList;
        }

        private void OrdersIco_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            ResetIcoColor();
            OrdersIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.Blue, 90);

            ObservableCollection<Backend.DataModels.Order> GridList = new ObservableCollection<Backend.DataModels.Order>();
            var entries = context.OrderRepository.Get();
            foreach (var entry in entries)
            {
                GridList.Add(entry);
            }
            GenericGrid.DataContext = GridList;
        }

        private void AddrIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetIcoColor();
            AddrIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.Blue, 90);

            ObservableCollection<Backend.DataModels.Address> GridList = new ObservableCollection<Backend.DataModels.Address>();
            var entries = context.AddressRepository.Get();
            foreach (var entry in entries)
            {
                GridList.Add(entry);
            }
            GenericGrid.DataContext = GridList;
        }

        private void Update_Entry(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                var gridList = (ObservableCollection<Address>)GenericGrid.DataContext;
                foreach (var entry in gridList)
                {
                    if (entry.Id != 0)
                    {
                        context.AddressRepository.Update(entry);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    var gridList = (ObservableCollection<Customer>) GenericGrid.DataContext;
                    foreach (var entry in gridList)
                    {
                        if (entry.Id != 0)
                        {
                            context.CustomerRepository.Update(entry);
                        }
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        var gridList = (ObservableCollection<Order>) GenericGrid.DataContext;
                        foreach (var entry in gridList)
                        {
                            if (entry.Id != 0)
                            {
                                context.OrderRepository.Update(entry);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            var gridList = (ObservableCollection<Product>) GenericGrid.DataContext;
                            foreach (var entry in gridList)
                            {
                                if (entry.Id != 0)
                                {
                                    context.ProductRepository.Update(entry);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            try
                            {
                                var gridList = (ObservableCollection<ProductGroup>) GenericGrid.DataContext;
                                foreach (var entry in gridList)
                                {
                                    if (entry.Id != 0)
                                    {
                                        context.ProductGroupRepository.Update(entry);
                                    }
                                }
                            }
                            catch (Exception exception2)
                            {
                                Console.WriteLine(exception2);
                                throw;
                            }
                        }
                    }
                }
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            AddEntry addWindow = new AddEntry();
            addWindow.Show();
            var table = GenericGrid.Columns;

            try
            {
                addWindow.one.Content = (string)table[1].Header;
                addWindow.two.Content = (string)table[2].Header;
                addWindow.three.Content = (string)table[3].Header;
                addWindow.four.Content = (string)table[4].Header;
                addWindow.five.Content = (string)table[5].Header;
            }
            catch (Exception exception)
            {
                addWindow.one.Content = (string)table[1].Header;
                addWindow.two.Content = (string)table[2].Header;
                addWindow.three.Content = (string)table[3].Header;
                addWindow.four.Content = (string)table[4].Header;
            }

            if ((string)table[1].Header == "Street")
            {
                addWindow.TxtFive.Text = DateTimeOffset.Now.ToString();
            }
            else if ((string) table[2].Header == "Firstname")
            {
                ObservableCollection<Address> list = new ObservableCollection<Address>();
                var entries = context.AddressRepository.Get();
                foreach (var entry in entries)
                {
                    list.Add(entry);
                }
                addWindow.StkFour.Children.Remove(addWindow.TxtFour);
                var box = new ComboBox
                {
                    Name = "combo",
                    FontSize = 33,
                    ItemsSource = {Binding list}
                };
                addWindow.StkFour.Children.Add(box);
                addWindow.TxtThree.IsEnabled = false;
                addWindow.TxtThree.Background = new SolidColorBrush(Colors.Gray);
            }
            else if ((string) table[2].Header == "Price")
            {

            }
            else if ((string)table[1].Header == "Date")
            {

            }
            else if ((string) table[5].Header == "Parent")
            {

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
=======

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
        }

        private void SetActivePage<T>() where T : IHasId
        {
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
                // Add here for other saves
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
>>>>>>> main
        }
    }
}
