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
        Database1Entities1 context = new Database1Entities1();
        CollectionViewSource custViewSource;
        public newDelivery()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("productViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource manufacturerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            context.product.Load();
            custViewSource.Source = context.product.Local;
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
         
        }
    }
}
