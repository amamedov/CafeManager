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
using Core;
using Models;

namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserService userService;
        User user;

        public MainWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var rw = new RegistrationWindow(userService);
            Hide();
            rw.ShowDialog();
            Show();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text) && string.IsNullOrEmpty(PasswordBox.Password))
            {
                if (userService.SignIn(LoginTextBox.Text, PasswordBox.Password, out string message, out user))
                {
                }
                else
                {
                    MessageBox.Show(message);
                    LoginTextBox.Clear();
                    PasswordBox.Clear();
                    LoginTextBox.Focus();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(LoginTextBox.Text))
                {
                    MessageBox.Show("Enter login, please");
                    PasswordBox.Clear();
                    LoginTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("Enter password, please");
                    PasswordBox.Focus();
                }
            }
        }
    }
}
