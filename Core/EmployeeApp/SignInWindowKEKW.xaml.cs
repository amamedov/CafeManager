using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeApp
{
    /// <summary>
    /// Логика взаимодействия для SignInWindowKEKW.xaml
    /// </summary>
    public partial class SignInWindowKEKW : Window
    {
        EmployeeService service;
        public SignInWindowKEKW()
        {
            service = new EmployeeService();
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (!service.SignIn(LoginTextBox.Text, PasswordBox.Password, out string message, out Employee employee))
            {
                MessageBox.Show(message);
                LoginTextBox.Clear();
                PasswordBox.Clear();
            }
            else
            {
                var mainWindow = new MainWindow(service, employee);
                Hide();
                mainWindow.ShowDialog();
                Show();

            }
        }
    }
}
