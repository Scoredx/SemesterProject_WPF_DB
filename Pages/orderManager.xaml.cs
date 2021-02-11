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
    /// Interaction logic for orderManager.xaml
    /// </summary>
    public partial class orderManager : Window
    {
        Database1Entities1 db = new Database1Entities1();

        public orderManager()
        {
            InitializeComponent();
            //this.orderDataGrid.ItemsSource = db.orderTable.ToList();



            //var data = (from order in db.orderTable.ToList()
            //            join product in db.product
            //            on order.order_product_id equals product.product_id
            //            select new
            //            {
            //                ProductID = product.product_id
            //            }).ToList();

            //orderDataGrid.DataSource = data;


            var data = (from order in db.orderTable.ToList()
                        join product in db.product
                        on order.order_id equals product.product_id
                        join customer in db.customer
                        on order.order_id equals customer.customer_id
                        join worker in db.worker
                        on order.order_id equals worker.worker_id
                        join delivery in db.delivery_type
                        on order.order_delivery_type_id equals delivery.delivery_type_id
                        select new
                        {
                            OrderID = order.order_id,
                            Product = product.product_name,
                            Customer = customer.customer_name,
                            Worker = worker.worker_id,
                            DeliveryType = delivery.delivery_type1,
                            OrderDate = order.order_date
                        }).ToList();


            this.orderDataGrid.ItemsSource = data;
        }

        private void productGrid_Selection(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
