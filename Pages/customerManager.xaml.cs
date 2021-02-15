using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SemesterProject_WPF_DB
{
    /// <summary>
    /// Interaction logic for customerManager.xaml
    /// </summary>
    public partial class customerManager : Window
    {
        Database1Entities1 db = new Database1Entities1();

        /// <summary>
        /// Initializes UI elements and puts the data from customer Table into datagrid using a public class as an Object
        /// </summary>
        public customerManager()
        {
            InitializeComponent();
            ReloadList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        
        }
        private void button_ReloadList(object sender, RoutedEventArgs e)
        {
            ReloadList();
        }
        private void button_createNewCustomer_click(object sender, RoutedEventArgs e)
        {
            if (customer_nameTextBox.Text != "" && customer_surnameTextBox.Text != "" && customer_address_idTextBox.Text != "" && customer_phoneTextBox.Text != "")
            {
                customer customerObj = new customer();
                int addressInt = checkAddresstQan(customer_address_idTextBox.Text);
                if (addressInt == -1)
                {
                    MessageBox.Show($"There is no such address ID.");
                    return;
                }
                else if (addressInt == 0)
                {
                    MessageBox.Show("Adress ID must contain only digits.");
                    return;
                }
                int phoneInt;
                bool phoneResult = int.TryParse(customer_phoneTextBox.Text, out phoneInt);
                if (!phoneResult)
                {
                    if (phoneInt >= 1_000_000_000 || phoneInt <= 99_999_999)
                    {
                        MessageBox.Show("Invalid Phone number length.");
                        return;
                    }
                    MessageBox.Show("Phone number must cointain only digits");
                    return;
                }
                if (customerObj != null)
                {
                    customerObj.customer_name = this.customer_nameTextBox.Text;
                    customerObj.customer_surename = this.customer_surnameTextBox.Text;
                    customerObj.customer_address_id = addressInt;
                    customerObj.customer_phone = phoneInt;
                    customerObj.customer_email = this.customer_emailTextBox.Text;
                    customerObj.customer_nip = this.customer_nipTextBox.Text;
                }
                db.customer.Add(customerObj);
                db.SaveChanges();
                clearTextBox();
                ReloadList();
            }
            else
            {
                MessageBox.Show("All important fields must be filled");
            }
        }
        private void button_updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (customer_nameTextBox.Text != "" && customer_surnameTextBox.Text != "" && customer_address_idTextBox.Text != "" && customer_phoneTextBox.Text != "")
            {
                var customerObject = db.customer.FirstOrDefault(y => y.customer_id == customerID);
                int addressInt = checkAddresstQan(customer_address_idTextBox.Text);
                if (addressInt == -1)
                {
                    MessageBox.Show($"There is no such address ID.");
                    return;
                }
                else if (addressInt == 0)
                {
                    MessageBox.Show("Adress ID must contain only digits.");
                    return;
                }
                int phoneInt;
                bool phoneResult = int.TryParse(customer_phoneTextBox.Text, out phoneInt);
                if (!phoneResult)
                {
                    if(phoneInt >= 1_000_000_000 || phoneInt <= 99_999_999)
                    {
                        MessageBox.Show("Invalid Phone number length.");
                        return;
                    }
                    MessageBox.Show("Phone number must cointain only digits");
                    return;
                }
                if (customerObject != null)
                {
                    customerObject.customer_name = this.customer_nameTextBox.Text;
                    customerObject.customer_surename = this.customer_surnameTextBox.Text;
                    customerObject.customer_address_id = addressInt;
                    customerObject.customer_phone = phoneInt;
                    customerObject.customer_email = this.customer_emailTextBox.Text;
                    customerObject.customer_nip = this.customer_nipTextBox.Text;
                }
                db.SaveChanges();
                clearTextBox();
                ReloadList();
            }
            else MessageBox.Show("All important fields must be filled");
        }
        private void button_deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var custmr = db.customer.FirstOrDefault(y => y.customer_id == customerID);
            if(custmr != null)
            {
                db.customer.Remove(custmr);
            }
            db.SaveChanges();
            clearTextBox();
            ReloadList();
        }
        private int customerID = 0;
        private void customerGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
            CustomerViewModel p = this.customerDataGrid.SelectedItem as CustomerViewModel;
            if (p is null)
            {
                this.customer_nameTextBox.Text = string.Empty;
                this.customer_surnameTextBox.Text = string.Empty;
                this.customer_address_idTextBox.Text = string.Empty;
                this.customer_phoneTextBox.Text = string.Empty;
                this.customer_emailTextBox.Text = string.Empty;
                this.customer_nipTextBox.Text = string.Empty;
                return;
            }
            this.customer_nameTextBox.Text = p.customer_name;
            this.customer_surnameTextBox.Text = p.customer_surname;
            this.customer_address_idTextBox.Text = p.address_id.ToString();
            this.customer_phoneTextBox.Text = p.customer_phone.ToString();
            this.customer_emailTextBox.Text = p.customer_email;
            this.customer_nipTextBox.Text = p.customer_nip;
            this.customerID = p.customer_id;
        }
        private int checkAddresstQan(string field) 
        {
            IQueryable<addressTable> count1 = db.addressTable;
            var addressQuantity = count1.Count();
            int addressIndexInt;
            bool addressIntResult = int.TryParse(field, out addressIndexInt);
            if (addressIntResult)
            {
                if (addressQuantity >= addressIndexInt)
                {
                    return addressIndexInt;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
        private void ReloadList() 
        {
            var customers = db.customer
              .Include("addressTable")
              .ToList();
            List<CustomerViewModel> displayItems = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                displayItems.Add(new CustomerViewModel
                {
                    customer_id = customer.customer_id,
                    customer_name = customer.customer_name,
                    customer_surname = customer.customer_surename,
                    address_id = customer.addressTable.address_id,
                    address_city = customer.addressTable.address_city,
                    customer_phone = customer.customer_phone,
                    customer_email = customer.customer_email,
                    customer_nip = customer.customer_nip,
                });
            }
            this.customerDataGrid.ItemsSource = displayItems;
        }
        private void clearTextBox()
        {
            this.customer_nameTextBox.Text = string.Empty;
            this.customer_surnameTextBox.Text = string.Empty;
            this.customer_address_idTextBox.Text = string.Empty;
            this.customer_phoneTextBox.Text = string.Empty;
            this.customer_emailTextBox.Text = string.Empty;
            this.customer_nipTextBox.Text = string.Empty;
        }

        private void button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
