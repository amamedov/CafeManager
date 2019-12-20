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

namespace OwnerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OwnerService service;
        public MainWindow()
        {
            InitializeComponent();
            service = new OwnerService();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeWindow = new EmployeeWindow(service);
            Hide();
            employeeWindow.ShowDialog();
            Show();
        }

        private void ProfitButton_Click(object sender, RoutedEventArgs e)
        {
            var profitWIndow = new ProfitWindow(service);
            Hide();
            profitWIndow.ShowDialog();
            Show();
        }

        private void IngridientsButton_Click(object sender, RoutedEventArgs e)
        {
            var ingredientWindow = new IngredientWindow(service);
            Hide();
            ingredientWindow.ShowDialog();
            Show();
        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            var feedbackWindow = new FeedbackWindow(service);
            Hide();
            feedbackWindow.ShowDialog();
            Show();
        }
    }
}
