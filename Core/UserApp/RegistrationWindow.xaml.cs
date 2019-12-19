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

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        UserService service;
        public RegistrationWindow(IService service)
        {
            InitializeComponent();
            this.service = service as UserService;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PhoneTextBox.Text) && string.IsNullOrEmpty(NameTextBox.Text) && string.IsNullOrEmpty(PasswordBox.Password) && string.IsNullOrEmpty(ConfirmPasswordBox.Password))
            {
                if (PasswordBox.Password == ConfirmPasswordBox.Password)
                {
                    if (service.SignUp(NameTextBox.Text, PhoneTextBox.Text, PasswordBox.Password, out string message, out User user))
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(message);
                        PhoneTextBox.Clear();
                        NameTextBox.Clear();
                        PasswordBox.Clear();
                        ConfirmPasswordBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Passwords in to fields should be equal");
                    PasswordBox.Clear();
                    ConfirmPasswordBox.Clear();
                    PasswordBox.Focus();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("Enter all fields to register");
                    NameTextBox.Focus();
                }
                if (string.IsNullOrEmpty(PhoneTextBox.Text))
                    PhoneTextBox.Focus();
                if (string.IsNullOrEmpty(PasswordBox.Password))
                    PasswordBox.Focus();
                if (string.IsNullOrEmpty(ConfirmPasswordBox.Password))
                    ConfirmPasswordBox.Focus();
            }
        }
    }
}
