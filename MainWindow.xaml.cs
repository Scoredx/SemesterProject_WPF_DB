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
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void newDelivery_button(object sender, RoutedEventArgs e)
        {
            newDelivery newDelivery = new newDelivery();
            newDelivery.Show();
        }

        private void productManager_button(object sender, RoutedEventArgs e)
        {
            productManager productManager = new productManager();
            productManager.Show();
        }
        private void orderManager_button(object sender, RoutedEventArgs e)
        {
            orderManager orderManager = new orderManager();
            orderManager.Show();
        }

        private void customerManager_button(object sender, RoutedEventArgs e)
        {
            customerManager customerManager = new customerManager();
            customerManager.Show();
        }

        private void staffManager_button(object sender, RoutedEventArgs e)
        {
            staffManager staffManager = new staffManager();
            staffManager.Show();
        }

        private void exit_button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
