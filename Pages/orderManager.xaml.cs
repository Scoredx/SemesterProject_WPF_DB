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
            ReloadList();


        }

        private void button_productNewProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productIndex.Text != "" && customerIndex.Text != "" && workerIndex.Text != "" && deliveryIndex.Text != "")
            {
                orderTable productObject = new orderTable()
                {
                    order_product_id = int.Parse(productIndex.Text),
                    order_customer_id = int.Parse(customerIndex.Text),
                    order_worker_id = int.Parse(workerIndex.Text),
                    order_delivery_type_id = int.Parse(deliveryIndex.Text),
                };
                db.orderTable.Add(productObject);
                db.SaveChanges();
                ReloadList();
            }
            else
            {
                MessageBox.Show("All fields must be filled");
            }

        }

        private void ReloadList()
        {
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
                    order.order_id,
                    order.product.product_name,
                    order.customer.customer_name,
                    order.worker.worker_id,
                    order.delivery_type.delivery_type1,
                    order.order_date
                });
            }
            this.orderDataGrid.ItemsSource = displayItems;
        }

        //private void AdjustColumnOrder()
        //{
        //    int x = 0;
        //    if (x == 0)
        //    {
        //        orderDataGrid.Columns[0].Width = 20;  //index
        //        orderDataGrid.Columns[1].Width = 90;  //Manufacturer
        //        orderDataGrid.Columns[2].Width = 100; //model name 
        //        orderDataGrid.Columns[3].Width = 120; //category
        //        orderDataGrid.Columns[4].Width = 100; //Price
        //        orderDataGrid.Columns[5].Width = 100; //Cost
        //        x++;
        //    }
        //}
    }
}
