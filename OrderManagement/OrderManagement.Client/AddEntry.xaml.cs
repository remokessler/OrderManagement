using System;
using System.Globalization;
using System.Windows;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Client
{
    /// <summary>
    /// Interaction logic for AddAddress.xaml
    /// </summary>
    public partial class AddEntry : Window
    {
        public AddEntry()
        {
            InitializeComponent();
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = (MainWindow) Application.Current.MainWindow;
            if (mainWin != null)
            {
                var table = mainWin.GenericGrid.Columns;

                if ((string)table[1].Header == "Street")
                {
                    if (TxtOne.Text != "" && TxtFive.Text != "" && TxtThree.Text != "" && TxtFour.Text != "" && TxtFive.Text != "")
                    {
                        Address address = new Address
                        {
                            Street = TxtOne.Text,
                            City = TxtTwo.Text,
                            PostCode = Convert.ToInt32(TxtThree.Text),
                            Country = TxtFour.Text,
                            From = Convert.ToDateTime(TxtFive.Text)
                        };
                        Backend.RepositoryCollection.Instance.AddressRepository.Add(address);
                    }
                }
                else if ((string)table[2].Header == "Firstname")
                {
                    if (TxtOne.Text != "" && TxtFive.Text != "" && TxtThree.Text != "" && TxtFour.Text != "" && TxtFive.Text != "")
                    {
                        Customer customer = new Customer
                        {
                            Name = TxtOne.Text,
                            Firstname = TxtTwo.Text,
                            
                            //AddressId = 
                        };
                        Backend.RepositoryCollection.Instance.CustomerRepository.Add(customer);
                    }
                }
                else if ((string)table[2].Header == "Price")
                {

                }
                else if ((string)table[1].Header == "Date")
                {

                }
                else if ((string)table[5].Header == "Parent")
                {

                }
            }
        }
    }
}
