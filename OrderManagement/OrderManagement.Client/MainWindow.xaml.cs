using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderManagement.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Customer> GridList = new ObservableCollection<Customer>();
        public MainWindow()
        {
            InitializeComponent();
            //GridList.Add(new Customer("Ebneter", "Marco", "Neumets nebedusse"));
            //GridList.Add(new Customer("Kessler", "Remo", "Neumet anders nebedusse"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GridList.Add(new Customer("Muster", "Ueli", "Save en zürcher"));
            //GenericGrid.DataContext = GridList;
        }

        public class Customer
        {
            public string Name { get; set; }
            public string Firstname { get; set; }
            public string Address { get; set; }

            public Customer(string name, string firstname, string address)
            {
                Name = name;
                Firstname = firstname;
                Address = address;
            }
        }

        public class Article
        {

        }

        private void CustomerIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ArticleGrpIco.Foreground = new  Colors.LightBlue;
            CustomerIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);
            MessageBox.Show("test");
        }

        private void ArticleGrpIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ArticleGrpIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

        }

        private void ArticleIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ArticleIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

        }

        private void OrdersIco_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            OrdersIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

        }

        private void ClickEvent(object sender, MouseButtonEventArgs e)
        {
            sender.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.Blue, 90)
        }
    }
}
