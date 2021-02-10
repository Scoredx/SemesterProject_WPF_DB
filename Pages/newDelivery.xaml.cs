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
using System.Collections;

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
            //ReloadList();
            this.productDataGrid.ItemsSource = db.product.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AdjustColumnOrder();
        }
        private void AdjustColumnOrder()
        {
            this.productDataGrid.Columns[6].Visibility = Visibility.Collapsed;
            productDataGrid.Columns[0].DisplayIndex = 0;
            productDataGrid.Columns[1].DisplayIndex = 2;
            productDataGrid.Columns[2].DisplayIndex = 1;
            productDataGrid.Columns[3].DisplayIndex = 1;
            productDataGrid.Columns[4].DisplayIndex = 4;
            productDataGrid.Columns[4].Header = "Cost";
            productDataGrid.Columns[4].Header = "Cost";
            productDataGrid.Columns[4].Header = "Cost";
            productDataGrid.Columns[4].Header = "Cost";
            productDataGrid.Columns[4].Header = "Cost";
            

        }

        //buttons 

        private void button_productNewProduct_Click(object sender, RoutedEventArgs e)
        {
            product productObject = new product()
            {
                product_name = product_NameTextBox.Text,
                product_category_name = product_CategoryTextBox.Text,
                product_manufacturer_name = product_ManufacturerTextBox.Text,
                product_price = decimal.Parse(product_PriceTextBox.Text),
                product_cost = decimal.Parse(product_CostTextBox.Text)
            };

            db.product.Add(productObject);
            db.SaveChanges();
            //ReloadList();
        }

        private void button_productReload_Click(object sender, RoutedEventArgs e)
        {
            //ReloadList();
            AdjustColumnOrder();

        }

        private void button_productCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void button_productDelete_Click(object sender, RoutedEventArgs e)
        {
            var row_list = GetDataGridRows(productDataGrid);
            foreach (DataGridRow single_row in row_list)
            {
                if (single_row.IsSelected == true)
                {
                    product p = (product)this.productDataGrid.SelectedItem;
                    this.product_ManufacturerTextBox2.Text = p.product_manufacturer_name;
                    this.product_NameTextBox2.Text = p.product_name;
                    this.product_CategoryTextBox2.Text = p.product_category_name;
                    this.product_PriceTextBox2.Text = p.product_price.ToString();
                    this.product_CostTextBox2.Text = p.product_cost.ToString();
                    if (p != null)
                    {
                        db.product.Remove(p);
                        //ReloadList();
                        db.SaveChanges();
                    }
                }
            }
        }

        private void productGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
            
            product p = this.productDataGrid.SelectedItem as product;
            if(p is null)
            {
                this.product_ManufacturerTextBox2.Text = string.Empty;
                this.product_NameTextBox2.Text = string.Empty;
                this.product_CategoryTextBox2.Text = string.Empty;
                this.product_PriceTextBox2.Text = string.Empty.ToString();
                this.product_CostTextBox2.Text = string.Empty.ToString();
                return;
            }
            this.product_ManufacturerTextBox2.Text = p.product_manufacturer_name;
            this.product_NameTextBox2.Text = p.product_name;
            this.product_CategoryTextBox2.Text = p.product_category_name;
            this.product_PriceTextBox2.Text = p.product_price.ToString();
            this.product_CostTextBox2.Text = p.product_cost.ToString();
        }



        private void button_productShowRawTable(object sender, RoutedEventArgs e)
        {
            this.productDataGrid.ItemsSource = db.product.ToList();

        }

        // usable
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        //private void ReloadList()
        //{
        //    var productlist = from x in db.product
        //                      select new
        //                      {
        //                          ProductId = x.product_id,
        //                          Category = x.product_category_name,
        //                          Manufacturer = x.product_manufacturer_name,
        //                          ProductName = x.product_name,
        //                          Price = x.product_price,
        //                          Cost = x.product_cost
        //                      };
        //    this.productDataGrid.ItemsSource = productlist.ToList();
        //}

    }
}
