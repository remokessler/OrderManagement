using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

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
            ArticleGrpIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            OrdersIco.Foreground = new SolidColorBrush(Colors.LightBlue);
        }

        private void CustomerIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetIcoColor();
            CustomerIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

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
            ArticleGrpIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

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
            ArticleIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

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
            OrdersIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

            ObservableCollection<Backend.DataModels.Order> GridList = new ObservableCollection<Backend.DataModels.Order>();
            var entries = context.OrderRepository.Get();
            foreach (var entry in entries)
            {
                GridList.Add(entry);
            }
            GenericGrid.DataContext = GridList;
        }

        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            //var marco = new Backend.DataModels.Customer();
            //marco.Id = 1;
            //marco.Firstname = "Marco";
            //marco.Name = "Ebneter";
            //context.CustomerRepository.Add(marco);

            //var testaddress = new Backend.DataModels.Address();
            //testaddress.Id = 1;
            //testaddress.Street = "teststrasse 15";
            //testaddress.Country = "ch";
            //testaddress.City = "appenzell";
            //testaddress.From = DateTime.Now;
            //testaddress.PostCode = 9050;
            //context.AddressRepository.Add(testaddress);
            AddAddress subwindow = new AddAddress();
            subwindow.Show();
        }
    }
}
