using Core;
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

namespace EmployeeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeService service;
        public MainWindow(EmployeeService service)
        {
            InitializeComponent();
            this.service = service;
            if (this.service.WorkingTime.StartDt is null)
            {
                EndWorkButton.IsEnabled = false;
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            service.LogOut();
            Close();
        }

        private void StartWorkButton_Click(object sender, RoutedEventArgs e)
        {
            service.StartWorking();
            StartWorkButton.IsEnabled = false;
            EndWorkButton.IsEnabled = true;
        }

        private void EndWorkButton_Click(object sender, RoutedEventArgs e)
        {
            service.EndWorking();
            StartWorkButton.IsEnabled = true;
            EndWorkButton.IsEnabled = false;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new MakeOrderWindow(service);
            Hide();
            orderWindow.ShowDialog();
            Show();
        }
    }
}
