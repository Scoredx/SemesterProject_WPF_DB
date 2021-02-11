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
        /// Initialize data from db with foregin keys
        /// </summary>
        public orderManager()
        {
            InitializeComponent();

            var orders = db.orderTable
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
                    OrderID = order.order_id,
                    Product = order.product.product_name,
                    Customer = order.customer.customer_name,
                    Worker = order.worker.worker_id,
                    DeliveryType = order.delivery_type.delivery_type1,
                    OrderDate = order.order_date
                });
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }

        private void productGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
