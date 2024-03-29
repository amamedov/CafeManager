﻿using Core;
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
    /// Логика взаимодействия для EmolyeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        OwnerService service;
        public EmployeeWindow(OwnerService service)
        {
            InitializeComponent();
            this.service = service;
            Employees.ItemsSource = service.GetAll<Employee>().Select(e => e.Phone);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var AddEmployee = new EmployeeReg(service);
            AddEmployee.ShowDialog();
            Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var employee = service.GetAll<Employee>().Find(e => e.Phone == Employees.SelectedItem.ToString());
            MessageBox.Show($"Name: {employee.Name}, Phone: {employee.Phone}, Position: {employee.Position}");
        }
    }
}
