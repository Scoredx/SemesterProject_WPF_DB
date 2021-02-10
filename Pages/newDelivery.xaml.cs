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
using System.Data.Entity;


namespace SemesterProject_WPF_DB
{
    /// <summary>
    /// Interaction logic for newDelivery.xaml
    /// </summary>
    public partial class newDelivery : Window
    {
        Database1Entities1 db = new Database1Entities1();

        public newDelivery()
        {
            InitializeComponent();
            ReloadList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //buttons 

        private void button_productNewProduct_Click(object sender, RoutedEventArgs e)
        {
            product productObject = new product()
            {
                product_name = product_NameTextBox.Text,
                product_category_name = product_CategoryTextBox.Text,
                product_manufacturer_name = product_ManufacturerTextBox.Text,
                product_price = int.Parse(product_PriceTextBox.Text),
                product_cost = int.Parse(product_CostTextBox.Text)
            };

            db.product.Add(productObject);
            db.SaveChanges();
            ReloadList();
        }

        private void button_productReload_Click(object sender, RoutedEventArgs e)
        {
            ReloadList();
        }

        private void button_productCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button_productDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        //private int productId = 0;
        private void productGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
            
        }


       // usable functions
       private void ReloadList()
        {
            var productlist = from x in db.product
                              select new
                              {
                                  ProductId = x.product_id,
                                  Category = x.product_category_name,
                                  Manufacturer = x.product_manufacturer_name,
                                  ProductName = x.product_name,
                                  Price = x.product_price,
                                  Cost = x.product_cost
                              };
            this.productDataGrid.ItemsSource = productlist.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db
        }
    }
}
