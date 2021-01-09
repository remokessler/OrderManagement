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
            ArticleGrpIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            OrdersIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            CustomerIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

            // TODO Connect to Backend for SELECT data
            var context = new Backend.RepositoryCollection();
            var nentry = new Customer();
            var entries = context.CustomerRepository.Get();
            foreach (var entry in entries)
            {
                MessageBox.Show("test");
            }
        }

        private void ArticleGrpIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CustomerIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            OrdersIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleGrpIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

        }

        private void ArticleIco_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ArticleGrpIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            CustomerIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            OrdersIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

        }

        private void OrdersIco_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            ArticleGrpIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            ArticleIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            CustomerIco.Foreground = new SolidColorBrush(Colors.LightBlue);
            OrdersIco.Foreground = new LinearGradientBrush(Colors.LightBlue, Colors.DarkBlue, 90);

        }
    }
}
