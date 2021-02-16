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
using SemesterProject_WPF_DB.Classes;

namespace SemesterProject_WPF_DB
{
    /// <summary>
    /// Interaction logic for customerManager.xaml
    /// Contains basic SQL Crud functions  
    /// </summary>
    public partial class staffManager : Window
    {
        WorkerService WorkerService = new WorkerService();

        /// <summary>
        /// Initializes UI and puts the data from worker Table into dataGrid using a public class as an Object
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
                worker workerObject = new worker();
                long peselInt;
                bool peselIntResult = long.TryParse(worker_peselTextBox.Text, out peselInt);
                if (!peselIntResult)
                {
                    MessageBox.Show("Pesel must be a number");
                    return;
                }
                var peselLength = worker_peselTextBox.Text.Length;
                if (peselLength != 11)
                {
                    MessageBox.Show("Invalid Pesel length, must be 11 digits!");
                    return;
                }
                if (workerObject != null)
                {
                    workerObject.worker_name = this.worker_nameTextBox.Text;
                    workerObject.worker_surename = this.worker_surnameTextBox.Text;
                    workerObject.worker_pesel = peselInt.ToString();
                }
                WorkerService.NewWorker(workerObject);
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
                var workerObject = WorkerService.SelectWorkerById(workerID);

                long peselInt;
                bool peselIntResult = long.TryParse(worker_peselTextBox.Text, out peselInt);
                if (!peselIntResult)
                {
                    MessageBox.Show("Pesel must be a number");
                    return;
                }
                var peselLength = worker_peselTextBox.Text.Length;
                if (peselLength != 11)
                {
                    MessageBox.Show("Invalid Pesel length, must be 11 digits!");
                    return;
                }
                WorkerService.UpdateWorker(workerObject, worker_nameTextBox.Text, worker_surnameTextBox.Text, worker_peselTextBox.Text);
                clearTextBox();
                ReloadList();
            }
            else MessageBox.Show("All important fields must be filled");
        }
        private void button_deleteWorker_Click(object sender, RoutedEventArgs e)
        {
            var worker = WorkerService.SelectWorkerById(workerID);
            WorkerService.RemoveWorker(worker);
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
        
            this.workerDataGrid.ItemsSource = WorkerService.GetList();
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
