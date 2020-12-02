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
        public ObservableCollection<TestObject> GridList = new ObservableCollection<TestObject>();
        public MainWindow()
        {
            InitializeComponent();
            GridList.Add(new TestObject("Ebneter", "Marco", "Neumets nebedusse"));
            GridList.Add(new TestObject("Kessler", "Remo", "Neumet anders nebedusse"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GridList.Add(new TestObject("Muster", "Ueli", "Save en zürcher"));
            GenericGrid.DataContext = GridList;
        }

        public class TestObject
        {
            public string Name { get; set; }
            public string Firstname { get; set; }
            public string Adress { get; set; }

            public TestObject(string name, string firstname, string adress)
            {
                Name = name;
                Firstname = firstname;
                Adress = adress;
            }
        }
    }
}
