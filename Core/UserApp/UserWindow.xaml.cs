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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        UserService service;
        public UserWindow(UserService userService)
        {
            InitializeComponent();
            service = userService;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            service.Logout();
            Close();
        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            var feedbackWindow = new FeedbackWindow(service);
            Hide();
            feedbackWindow.ShowDialog();
            Show();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            OrderListBox.SelectedItems.Clear();
        }
    }
}
