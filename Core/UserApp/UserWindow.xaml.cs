using Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        User user;
        public UserWindow(UserService userService, User user)
        {
            InitializeComponent();
            this.user = user;
            service = userService;
            OrderListBox.ItemsSource = service.PossibleChoice().Select(o => o.Name);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            service.Logout();
            Close();
        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            var feedbackWindow = new FeedbackWindow(service, user);
            Hide();
            feedbackWindow.ShowDialog();
            Show();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            OrderListBox.SelectedItems.Clear();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListBox.SelectedItems != null)
                service.CreateOrder(service.GetAll<MenuPosition>().Where(m => OrderListBox.SelectedItems.Contains(m.Name)).ToList(), false);
        }
    }
}
