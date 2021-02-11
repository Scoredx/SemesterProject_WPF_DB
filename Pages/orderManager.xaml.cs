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
            var tarifas = (from t in db.orderTable.Include("product")
                           select t);

            this.orderDataGrid.ItemsSource = tarifas.ToList();

        }

        private void productGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
        }



        
    }
}
