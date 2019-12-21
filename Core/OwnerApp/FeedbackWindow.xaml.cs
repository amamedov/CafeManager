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

namespace OwnerApp
{
    /// <summary>
    /// Логика взаимодействия для FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        OwnerService service;
        public FeedbackWindow(OwnerService service)
        {
            InitializeComponent();
            this.service = service;
            FeedbackListBox.ItemsSource = service.GetAll<FeedBack>().Select(f => f.UsersFeedBack);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            var feedback = service.GetAll<FeedBack>().Find(f => f.UsersFeedBack == FeedbackListBox.SelectedItem.ToString());
            feedback.Seen = true;
            service.Update(feedback);
        }
    }
}
