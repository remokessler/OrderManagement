using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        private void Update_Entry(object sender, SelectedCellsChangedEventArgs e)
        {
            ObservableCollection<Backend.DataModels.Address> GridList = new ObservableCollection<Backend.DataModels.Address>();

            var idx = GenericGrid.SelectedIndex;
            GridList += GenericGrid.DataContextChanged(idx);

            Address[] addr;
            addr = new Address[1];
            GridList.CopyTo(addr, idx);
            //context.AddressRepository.Add(addr);
            MessageBox.Show(Convert.ToString(addr));
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
