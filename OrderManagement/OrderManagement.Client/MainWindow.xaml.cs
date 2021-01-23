using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Backend.RepositoryCollection context = new Backend.RepositoryCollection();

        public MainWindow()
        {
            InitializeComponent();
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
        }
    }
}
