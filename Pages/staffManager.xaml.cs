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
    /// Interaction logic for customerManager.xaml
    /// Contains basic SQL Crud functions  
    /// </summary>
    public partial class staffManager : Window
    {
        Database1Entities1 db = new Database1Entities1();

        /// <summary>
        /// Initializes UI and puts the data from worker Table into datagrid using a public class as an Object
        /// </summary>
        public staffManager()
        {
            InitializeComponent();
            ReloadList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void button_ReloadList(object sender, RoutedEventArgs e)
        {
            ReloadList();
        }
        private void button_createNewWorker_click(object sender, RoutedEventArgs e)
        {
            if (worker_nameTextBox.Text != "" && worker_surnameTextBox.Text != "" && worker_peselTextBox.Text != "")
            {
                worker customerObj = new worker();
                var x = this.worker_peselTextBox.Text.Count();
                if (x != 11)
                {
                    MessageBox.Show("Pesel must have 11 digits");
                    return;
                }
                long workerInt;
                bool workerIntResult = long.TryParse(worker_peselTextBox.Text, out workerInt);
                if (!workerIntResult)
                {
                    MessageBox.Show("Pesel must be a number");
                    return;
                }
                if (customerObj != null)
                {
                    customerObj.worker_name = this.worker_nameTextBox.Text;
                    customerObj.worker_surename = this.worker_surnameTextBox.Text;
                    customerObj.worker_pesel = workerInt.ToString();
                }
                db.worker.Add(customerObj);
                db.SaveChanges();
                clearTextBox();
                ReloadList();
            }
            else
            {
                MessageBox.Show("All important fields must be filled");
            }
        }
        private void button_updateWorker_Click(object sender, RoutedEventArgs e)
        {
            if (worker_nameTextBox.Text != "" && worker_surnameTextBox.Text != "" && worker_peselTextBox.Text != "")
            {
                var customerObject = db.worker.FirstOrDefault(y => y.worker_id == workerID);

                if (customerObject != null)
                {
                    customerObject.worker_name = this.worker_nameTextBox.Text;
                    customerObject.worker_surename = this.worker_surnameTextBox.Text;
                    customerObject.worker_pesel = this.worker_peselTextBox.Text;
                }
                db.SaveChanges();
                clearTextBox();
                ReloadList();
            }
            else MessageBox.Show("All important fields must be filled");
        }
        private void button_deleteWorker_Click(object sender, RoutedEventArgs e)
        {
            var custmr = db.worker.FirstOrDefault(y => y.worker_id == workerID);
            if (custmr != null) db.worker.Remove(custmr);
            db.SaveChanges();
            clearTextBox();
            ReloadList();
        }
        private int workerID = 0;
        private void workerGrid_Selection(object sender, SelectionChangedEventArgs e)
        {
            WorkerViewModel p = this.workerDataGrid.SelectedItem as WorkerViewModel;
            if (p is null)
            {
                this.worker_nameTextBox.Text = string.Empty;
                this.worker_surnameTextBox.Text = string.Empty;
                this.worker_peselTextBox.Text = string.Empty;
                return;
            }
            this.worker_nameTextBox.Text = p.worker_name;
            this.worker_surnameTextBox.Text = p.worker_surname;
            this.worker_peselTextBox.Text = p.worker_pesel.ToString();
            this.workerID = p.worker_id;
        }
        private void ReloadList()
        {
            var customers = db.worker
              .ToList();
            List<WorkerViewModel> displayItems = new List<WorkerViewModel>();
            foreach (var worker in customers)
            {
                displayItems.Add(new WorkerViewModel
                {
                    worker_id = worker.worker_id,
                    worker_name = worker.worker_name,
                    worker_surname = worker.worker_surename,
                    worker_pesel = worker.worker_pesel
                });
            }
            this.workerDataGrid.ItemsSource = displayItems;
        }
        private void clearTextBox()
        {
            this.worker_nameTextBox.Text = string.Empty;
            this.worker_surnameTextBox.Text = string.Empty;
            this.worker_peselTextBox.Text = string.Empty;
        }
        private void button_exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
