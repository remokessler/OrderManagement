using OrderManagement.Backend;
using OrderManagement.Backend.DataModels;
using OrderManagement.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

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
            if (Header.Content.ToString() == "BillStats")
                SetStatisticPageActive();
            if (Header.Content.ToString() == "YearStats")
                SetYearStatisticPageActive();

            HighlightSelectedPageInMenu();
        }

        private void SetTreePageActive()
        {
            GenericGrid.Columns.Clear();
            GenericGrid.Visibility = Visibility.Hidden;
            GenericTree.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Hidden;
            SaveButton.Visibility = Visibility.Hidden;
            Filter.Visibility = Visibility.Hidden;
            FilterGrid.Visibility = Visibility.Hidden;
            GenericGrid.CanUserAddRows = false;
            _page = new ActivePage<ProductGroup>(RepositoryCollection.Instance.ProductTreeRepository, true);
            GenericTree.Items.Clear();
            GenericTree.Items.Add(RepositoryCollection.Instance.ProductTreeRepository.Get("1"));
        }

        private void SetStatisticPageActive()
        {
            GenericGrid.Columns.Clear();
            GenericGrid.Visibility = Visibility.Visible;
            GenericTree.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;
            SaveButton.Visibility = Visibility.Hidden;
            Filter.Visibility = Visibility.Visible;
            FilterGrid.Visibility = Visibility.Hidden;
            GenericGrid.CanUserAddRows = false;
            var page = new ActivePage<BillStatistic>(RepositoryCollection.Instance.BillStatisticRepository);
            _page = page;
            GenericGrid.DataContext = page.ObservableCollection;
        }

        private void SetYearStatisticPageActive()
        {
            GenericGrid.Visibility = Visibility.Visible;
            GenericTree.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;
            SaveButton.Visibility = Visibility.Hidden;
            Filter.Visibility = Visibility.Hidden;
            FilterGrid.Visibility = Visibility.Hidden;
            var page = new ActivePage<YearStatistic>(RepositoryCollection.Instance.YearStatisticRepository);
            _page = page;
            var statistics = RepositoryCollection.Instance.YearStatisticRepository.Get().ToArray();
            var pivotedList = new[] {
                CreateStatisticObject(statistics, "AvgCountProductsPerOrder", x => x.AvgCountProductsPerOrder.ToString()),
                CreateStatisticObject(statistics, "CountProducts", x => x.CountProducts.ToString()),
                CreateStatisticObject(statistics, "CountOrders", x => x.CountOrders.ToString()),
                CreateStatisticObject(statistics, "AvgSalesPerCustomer", x => x.AvgSalesPerCustomer.ToString()),
                CreateStatisticObject(statistics, "TotalSales", x => x.TotalSales.ToString()),
            };
            GenericGrid.Columns.Clear();
            GenericGrid.DataContext = new ObservableCollection<object>(pivotedList);
            GenericGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Category",
                Binding = new Binding("Category")
            });
            GenericGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "Year",
                Binding = new Binding("Year")
            });
            for (int i = 0; i < statistics.Count(); i++)
            {
                var column = new DataGridTextColumn
                {
                    Header = "Q" + statistics[i].Quarter + "-" + statistics[i].Year,
                    Binding = new Binding("Q" + statistics[i].Quarter + "-" + statistics[i].Year)
                };
                GenericGrid.Columns.Add(column);
            }
            GenericGrid.CanUserAddRows = false;
        }

        private object CreateStatisticObject(YearStatistic[] statistics, string propName, Func<YearStatistic, string> setProp)
        {
            dynamic expando = new ExpandoObject();
            expando.Category = propName;
            expando.Year = DateTime.Now;
            for (int i = 0; i < statistics.Count(); i++)
            {
                ((IDictionary<string, object>)expando)["Q" + statistics[i].Quarter + "-" + statistics[i].Year] = setProp(statistics[i]);
            }
            return expando as ExpandoObject;
        }

        private void SetActivePage<T>() where T : IHasId
        {
            GenericGrid.Columns.Clear();
            GenericGrid.Visibility = Visibility.Visible;
            GenericTree.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Visible;
            SaveButton.Visibility = Visibility.Visible;
            Filter.Visibility = Visibility.Hidden;
            FilterGrid.Visibility = Visibility.Hidden;
            GenericGrid.CanUserAddRows = true;
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
                    e.Row.Item = UpdateOrInsert<Address>(e.Row.Item);
                    break;
                case "Customer":
                    e.Row.Item = UpdateOrInsert<Customer>(e.Row.Item);
                    break;
                case "Order":
                    e.Row.Item = UpdateOrInsert<Order>(e.Row.Item);
                    break;
                case "OrderPosition":
                    e.Row.Item = UpdateOrInsert<OrderPosition>(e.Row.Item);
                    break;
                case "Product":
                    e.Row.Item = UpdateOrInsert<Product>(e.Row.Item);
                    break;
                case "ProductGroup":
                    e.Row.Item = UpdateOrInsert<ProductGroup>(e.Row.Item);
                    break;
            }
        }

        private T UpdateOrInsert<T>(object rowItem) where T : IHasId
        {
            var item = (T)rowItem;
            //try
            //{
                var repository = GetActivePage<T>().Repository;
                if (item.Id == null)
                    item = repository.Add(item);
                else
                    item = repository.Update(item);
            //if (item == null || item.Id == null)
            //    MessageBox.Show("The dataset could not be updated due to missing information.", "Missing data", MessageBoxButton.OK, MessageBoxImage.Warning);

            //}
            //catch
            //{
            //    MessageBox.Show("An error occurred while saving.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
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

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if (FilterGrid.Visibility == Visibility.Visible)
            {
                ResetFilter.Visibility = Visibility.Hidden;
                Filter.SetValue(Grid.ColumnSpanProperty, 2);
                FilterGrid.Visibility = Visibility.Hidden;
                GenericGrid.Visibility = Visibility.Visible;
                Filter.Content = "Filter";
                GenericGrid.DataContext = GetActivePage<BillStatistic>().Repository.Get(
                    b =>
                        b.CustomerId.ToString().Contains(FilterCustomerNumber.Text)
                        && b.AmountGross.ToString().Contains(FilterAmountGross.Text)
                        && b.AmountNet.ToString().Contains(FilterAmountNet.Text)
                        && b.Date.ToString().Contains(FilterBillDate.Text)
                        && b.Id.ToString().Contains(FilterBillId.Text)
                        && b.City.ToString().Contains(FilterCity.Text)
                        && b.Country.ToString().Contains(FilterCountry.Text)
                        && b.CustomerName.ToString().Contains(FilterFullName.Text)
                        && b.PostCode.ToString().Contains(FilterPostCode.Text)
                        && b.Street.ToString().Contains(FilterStreet.Text));
            }
            else
            {
                ResetFilter.Visibility = Visibility.Visible;
                Filter.SetValue(Grid.ColumnSpanProperty, 1);
                FilterGrid.Visibility = Visibility.Visible;
                GenericGrid.Visibility = Visibility.Hidden;
                Filter.Content = "Search";
            }
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterCustomerNumber.Text = string.Empty;
            FilterFullName.Text = string.Empty;
            FilterBillDate.Text = string.Empty;
            FilterBillId.Text = string.Empty;
            FilterAmountNet.Text = string.Empty;
            FilterAmountGross.Text = string.Empty;
            FilterStreet.Text = string.Empty;
            FilterPostCode.Text = string.Empty;
            FilterCity.Text = string.Empty;
            FilterCountry.Text = string.Empty;
        }

        private void HighlightSelectedPageInMenu()
        {
            ResetSelectedPageInMenu();

            if (Header.Content.ToString() == "Customer")
                Customer.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "Address")
                Address.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "Product")
                Product.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "ProductGroup")
                ProductGroup.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "Order")
                Order.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "OrderPosition")
                OrderPosition.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "ProductTree")
                ProductTree.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "BillStats")
                BillStats.Background = Brushes.DarkGray;
            else if (Header.Content.ToString() == "YearStats")
                YearStats.Background = Brushes.DarkGray;
        }

        private void ResetSelectedPageInMenu()
        {
            Customer.Background = Brushes.Transparent;
            Address.Background = Brushes.Transparent;
            Product.Background = Brushes.Transparent;
            ProductGroup.Background = Brushes.Transparent;
            Order.Background = Brushes.Transparent;
            OrderPosition.Background = Brushes.Transparent;
            ProductTree.Background = Brushes.Transparent;
            BillStats.Background = Brushes.Transparent;
            YearStats.Background = Brushes.Transparent;
        }

    }
}
