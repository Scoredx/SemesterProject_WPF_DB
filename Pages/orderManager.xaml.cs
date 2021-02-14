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
    /// </summary>
    public partial class orderManager : Window
    {
        Database1Entities1 db = new Database1Entities1();

        /// <summary>
        /// Initialize UI  and  data from db with foregin keys as readable text
        /// </summary>
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

        private void button_productNewProduct_Click(object sender, RoutedEventArgs e) /////////////////////// create New Product
        {
            if (productIndex.Text != "" && customerIndex.Text != "" && workerIndex.Text != "" && deliveryIndex.Text != "")
            {
                int productID = checkProductQan(productIndex.Text);
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

                int customerID = checkCustomerQan(customerIndex.Text);
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

                int workerID = checkWorkerQan(workerIndex.Text);
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

                int deliveryID = checkDeliveryTypeQan(deliveryIndex.Text);
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
                db.orderTable.Add(productObject);
                db.SaveChanges();
                ReloadList();
            }
            else
            {
                MessageBox.Show("There is an empty field");
            }
        }
        private int checkProductQan(string field) /////////////////////// check Product Qantity
        {
            IQueryable<product> count1 = db.product;
            var productsQuantity = count1.Count();

            int productIndexInt;
            bool productIntResult = int.TryParse(field, out productIndexInt);
            if (productIntResult)
            {
                if (productsQuantity >= productIndexInt)
                {
                    return productIndexInt;
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
        private int checkCustomerQan(string field) /////////////////////// check Product Qantity 
        {
            IQueryable<customer> count1 = db.customer;
            var productsQuantity = count1.Count();

            int customerIndexInt;
            bool customertIntResult = int.TryParse(field, out customerIndexInt);
            if (customertIntResult)
            {
                if (productsQuantity >= customerIndexInt)
                {
                    return customerIndexInt;
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
        private int checkWorkerQan(string field) /////////////////////// check Worker Qantity
        {
            IQueryable<worker> count1 = db.worker;
            var workerQuantity = count1.Count();

            int workerIndexResult;
            bool workerIntResult = int.TryParse(field, out workerIndexResult);
            if (workerIntResult)
            {
                if (workerQuantity >= workerIndexResult)
                {
                    return workerIndexResult;
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
        private int checkDeliveryTypeQan(string field) /////////////////////// check DeliveryType Qantity
        {
            IQueryable<delivery_type> count1 = db.delivery_type;
            var productsQuantity = count1.Count();

            int deliveryIndexInt;
            bool deliveryIntResult = int.TryParse(field, out deliveryIndexInt);
            if (deliveryIntResult)
            {
                if (productsQuantity >= deliveryIndexInt)
                {
                    return deliveryIndexInt;
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
        private void SelectByProductID(object sender, RoutedEventArgs e) /////////////////////// select by product id 
        {
            int productID = checkProductQan(productIndex.Text);
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
            var orders = db.orderTable
              .Where(st => st.product.product_id == productID)
              .Include(x => x.product)
              .Include(x => x.customer)
              .Include(x => x.worker)
              .Include(x => x.delivery_type)
              .ToList();

            List<dynamic> displayItems = new List<dynamic>();
            foreach (var order in orders)
            {
                displayItems.Add(new
                {
                    order.order_id,
                    order.product.product_id,
                    order.product.product_name,
                    order.customer.customer_id,
                    order.customer.customer_name,
                    order.customer.customer_surename,
                    order.worker.worker_id,
                    order.order_delivery_type_id,
                    order.delivery_type.delivery_type1
                });
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void SelectByCustomerID(object sender, RoutedEventArgs e) /////////////////////// select by customer id 
        {
            int customerID = checkCustomerQan(customerIndex.Text);
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
            var orders = db.orderTable
              .Where(st => st.customer.customer_id == customerID)
              .Include(x => x.product)
              .Include(x => x.customer)
              .Include(x => x.worker)
              .Include(x => x.delivery_type)
              .ToList();

            List<dynamic> displayItems = new List<dynamic>();
            foreach (var order in orders)
            {
                displayItems.Add(new
                {
                    order.order_id,
                    order.product.product_id,
                    order.product.product_name,
                    order.customer.customer_id,
                    order.customer.customer_name,
                    order.customer.customer_surename,
                    order.worker.worker_id,
                    order.order_delivery_type_id,
                    order.delivery_type.delivery_type1
                });
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void SelectByWorkerID(object sender, RoutedEventArgs e) /////////////////////// select by worker id 
        {
            int workerID = checkWorkerQan(workerIndex.Text);
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
            var orders = db.orderTable
              .Where(st => st.worker.worker_id == workerID)
              .Include(x => x.product)
              .Include(x => x.customer)
              .Include(x => x.worker)
              .Include(x => x.delivery_type)
              .ToList();

            List<dynamic> displayItems = new List<dynamic>();
            foreach (var order in orders)
            {
                displayItems.Add(new
                {
                    order.order_id,
                    order.product.product_id,
                    order.product.product_name,
                    order.customer.customer_id,
                    order.customer.customer_name,
                    order.customer.customer_surename,
                    order.worker.worker_id,
                    order.order_delivery_type_id,
                    order.delivery_type.delivery_type1
                });
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }
        private void SelectByDeliveryID(object sender, RoutedEventArgs e) /////////////////////// select by delivery id 
        {
            int deliveryID = checkDeliveryTypeQan(deliveryIndex.Text);
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

            var orders = db.orderTable
              .Where(st => st.delivery_type.delivery_type_id == deliveryID)
              .Include(x => x.product)
              .Include(x => x.customer)
              .Include(x => x.worker)
              .Include(x => x.delivery_type)
              .ToList();

            List<dynamic> displayItems = new List<dynamic>();
            foreach (var order in orders)
            {
                displayItems.Add(new
                {
                    order.order_id,
                    order.product.product_id,
                    order.product.product_name,
                    order.customer.customer_id,
                    order.customer.customer_name,
                    order.customer.customer_surename,
                    order.worker.worker_id,
                    order.order_delivery_type_id,
                    order.delivery_type.delivery_type1
                });
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }

        private void ReloadList()//////////////////////////////// Raload List 
        {
            var orders = db.orderTable
              .Include(x => x.product)
              .Include(x => x.customer)
              .Include(x => x.worker)
              .Include(x => x.delivery_type)
              .ToList();

            List<OrderViewModel> displayItems = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                displayItems.Add(new OrderViewModel
                {
                    order_id = order.order_id,
                    product_id = order.product.product_id,
                    product_name = order.product.product_name,
                    customer_id = order.customer.customer_id,
                    customer_name = order.customer.customer_name,
                    customer_surname = order.customer.customer_surename,
                    worker_id = order.worker.worker_id,
                    delivery_type_id = order.order_delivery_type_id,
                    delivery_type1 = order.delivery_type.delivery_type1
                });
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
        } /////////////////////// checked box event
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            button_CreateNewOrder.Visibility = Visibility.Visible;

            filterByProduct.Visibility = Visibility.Collapsed;
            filterByDelivery.Visibility = Visibility.Collapsed;
            filterByWorker.Visibility = Visibility.Collapsed;
            filterByCustomer.Visibility = Visibility.Collapsed;
        } /////////////////////// unchecked box event 

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

