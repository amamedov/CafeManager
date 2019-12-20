using Core;
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

namespace OwnerApp
{
    /// <summary>
    /// Логика взаимодействия для EmolyeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        OwnerService service;
        public EmployeeWindow(OwnerService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
