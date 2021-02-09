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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;


namespace SemesterProject_WPF_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database1Entities context = new Database1Entities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;
        public MainWindow()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("customerViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("customerorderTableViewSource")));

            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource customerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("customerViewSource")));
            context.customer.Load();
            custViewSource.Source = context.customer.Local;
           
        }
        private void button_openDBViewer(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
        }

        private void button_newDelivery(object sender, RoutedEventArgs e)
        {

        }
        private void button_exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
