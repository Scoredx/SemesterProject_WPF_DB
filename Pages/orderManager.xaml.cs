using SemesterProject_WPF_DB.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for orderManager.xaml
    /// Contains basic SQL Crud Functions
    /// </summary>
    public partial class orderManager : Window
    {
        OrderService OrderService = new OrderService();
        /// <summary>
        /// Initialize UI  and  data from db with foreign keys as readable text
        /// </summary>

        /// ///<remarks>
        /// reload list writes order data table to data grid along with information connected to other tables with foreign keys
        /// </remarks>
        public orderManager()
        {
            InitializeComponent();
            ReloadList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            filterByProduct.Visibility = Visibility.Collapsed;
            filterByDelivery.Visibility = Visibility.Collapsed;
            filterByWorker.Visibility = Visibility.Collapsed;
            filterByCustomer.Visibility = Visibility.Collapsed;
        }
        private void button_productNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productIndex.Text != "" && customerIndex.Text != "" && workerIndex.Text != "" && deliveryIndex.Text != "")
            {
                int productID = OrderService.checkProductQan(productIndex.Text);
                if (productID == -1)
                {
                    MessageBox.Show($"There is no such Product.");
                    return;
                }
                else if (productID == 0)
                {
                    MessageBox.Show("Product Index must be number");
                    return;
                }

                int customerID = OrderService.checkCustomerQan(customerIndex.Text);
                if (customerID == -1)
                {
                    MessageBox.Show($"There is no such Customer.");
                    return;
                }
                else if (customerID == 0)
                {
                    MessageBox.Show("Customer Index must be number");
                    return;
                }

                int workerID = OrderService.checkWorkerQan(workerIndex.Text);
                if (workerID == -1)
                {
                    MessageBox.Show($"There is no such Worker.");
                    return;
                }
                else if (workerID == 0)
                {
                    MessageBox.Show("Worker Index must be number");
                    return;
                }

                int deliveryID = OrderService.checkDeliveryTypeQan(deliveryIndex.Text);
                if (deliveryID == -1)
                {
                    MessageBox.Show($"There is no such Delivery Type.");
                    return;
                }
                else if (deliveryID == 0)
                {
                    MessageBox.Show("Delivery Index must be number");
                    return;
                }
                orderTable productObject = new orderTable()
                {
                    order_product_id = productID,
                    order_customer_id = customerID,
                    order_worker_id = workerID,
                    order_delivery_type_id = deliveryID
                };
                OrderService.NewOrder(productObject);
                ReloadList();
            }
            else
            {
                MessageBox.Show("There is an empty field");
            }
        }
        private void SelectByProductID(object sender, RoutedEventArgs e) 
        {
            int productID = OrderService.checkProductQan(productIndex.Text);
            if (productID == -1)
            {
                MessageBox.Show($"There is no such Product.");
                return;
            }
            else if (productID == 0)
            {
                MessageBox.Show("Product Index must be number");
                return;
            }

            var orders = OrderService.GetProductById(productID);

            List<OrderViewModel> displayItems = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                displayItems.Add(new OrderViewModel(order));
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void SelectByCustomerID(object sender, RoutedEventArgs e) 
        {
            int customerID = OrderService.checkCustomerQan(customerIndex.Text);
            if (customerID == -1)
            {
                MessageBox.Show($"There is no such Customer.");
                return;
            }
            else if (customerID == 0)
            {
                MessageBox.Show("Customer Index must be number");
                return;
            }
            var orders = OrderService.GetCustomertById(customerID);

            List<OrderViewModel> displayItems = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                displayItems.Add(new OrderViewModel(order));
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void SelectByWorkerID(object sender, RoutedEventArgs e) 
        {
            int workerID = OrderService.checkWorkerQan(workerIndex.Text);
            if (workerID == -1)
            {
                MessageBox.Show($"There is no such Worker.");
                return;
            }
            else if (workerID == 0)
            {
                MessageBox.Show("Worker Index must be number");
                return;
            }
            var orders = OrderService.GetWorkerById(workerID);

            List<OrderViewModel> displayItems = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                displayItems.Add(new OrderViewModel(order));
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void SelectByDeliveryID(object sender, RoutedEventArgs e) 
        {
            int deliveryID = OrderService.checkDeliveryTypeQan(deliveryIndex.Text);
            if (deliveryID == -1)
            {
                MessageBox.Show($"There is no such Delivery Type.");
                return;
            }
            else if (deliveryID == 0)
            {
                MessageBox.Show("Delivery Index must be a number");
                return;
            }

            var orders = OrderService.GetDeliveryById(deliveryID);

            List<OrderViewModel> displayItems = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                displayItems.Add(new OrderViewModel(order));
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void ReloadList()
        {
            var orders = OrderService.GetList();

            List<OrderViewModel> displayItems = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                displayItems.Add(new OrderViewModel(order));
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            button_CreateNewOrder.Visibility = Visibility.Collapsed;

            filterByProduct.Visibility = Visibility.Visible;
            filterByDelivery.Visibility = Visibility.Visible;
            filterByWorker.Visibility = Visibility.Visible;
            filterByCustomer.Visibility = Visibility.Visible;
        } 
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            button_CreateNewOrder.Visibility = Visibility.Visible;

            filterByProduct.Visibility = Visibility.Collapsed;
            filterByDelivery.Visibility = Visibility.Collapsed;
            filterByWorker.Visibility = Visibility.Collapsed;
            filterByCustomer.Visibility = Visibility.Collapsed;
        }
        private void button_ReloadList(object sender, RoutedEventArgs e)
        {
            ReloadList();
        }
        private void button_closeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

