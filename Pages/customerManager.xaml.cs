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
using SemesterProject_WPF_DB.Classes;

namespace SemesterProject_WPF_DB
{
    /// <summary>
    /// Interaction logic for customerManager.xaml
    /// </summary>
    public partial class customerManager : Window
    {
        private CustomerService CustomerService = new CustomerService();
        /// <summary>
        /// Initializes UI elements and puts the data from customer Table into dataGrid using a public class as an Object
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
                int addressInt = CustomerService.checkAddresstQan(customer_address_idTextBox.Text);
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
                if(phoneResult)
                {
                    int phoneLength = phoneInt.ToString().ToCharArray().Length;
                    if (phoneLength <= 8 || phoneLength >= 10)
                    {
                        MessageBox.Show("Invalid Phone number length.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Phone number must contain only digits");
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
                CustomerService.NewCustomer(customerObj);
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
                var customerObject = CustomerService.SelectCustomerById(customerID);
                int addressInt = CustomerService.checkAddresstQan(customer_address_idTextBox.Text);
                if (addressInt == -1)
                {
                    MessageBox.Show($"There is no such address ID.");
                    return;
                }
                else if (addressInt == 0)
                {
                    MessageBox.Show("Address ID must contain only digits.");
                    return;
                }
                int phoneInt;
                bool phoneResult = int.TryParse(customer_phoneTextBox.Text, out phoneInt);
                if (phoneResult)
                {
                    int phoneLength = phoneInt.ToString().ToCharArray().Length;
                    if(phoneLength <= 8 || phoneLength >= 10)
                    {
                        MessageBox.Show("Invalid Phone number length.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Phone number must contain only digits");
                    return;
                }
                CustomerService.UpdateCustomer(customerObject, this.customer_nameTextBox.Text, this.customer_surnameTextBox.Text, addressInt, phoneInt, this.customer_emailTextBox.Text, this.customer_nipTextBox.Text);
                clearTextBox();
                ReloadList();
            }
            else MessageBox.Show("All important fields must be filled");
        }
        private void button_deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var cstmr = CustomerService.SelectCustomerById(customerID);
            CustomerService.DeleteCustomer(cstmr);
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
        private void ReloadList()
        {
            var customers = CustomerService.GetList();
            List<CustomerViewModel> displayItems = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                displayItems.Add(new CustomerViewModel(customer) );
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
