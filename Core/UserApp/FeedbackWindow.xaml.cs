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
    /// Логика взаимодействия для FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        UserService service;
        public FeedbackWindow( UserService userService)
        {
            InitializeComponent();
            service = userService;
        }

        private void CAncelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FeedbackTextBox.Text))
            {
                service.GiveFeedBack(FeedbackTextBox.Text);
            }
            else
            {
                MessageBox.Show("Can not submit empty comment");
                FeedbackTextBox.Focus();
            }
        }
    }
}
