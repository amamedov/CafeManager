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

namespace EmployeeApp
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        EmployeeService service;
        public MakeOrderWindow(EmployeeService service)
        {
            InitializeComponent();
            this.service = service;
            IngredientsListBox.ItemsSource = service.GetAll<Ingredient>().Select(i => i.Name);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            service.MakeIngredientsOrder(service.GetAll<Ingredient>().Where(i => IngredientsListBox.SelectedItems.Contains(i.Name)).Select(i => i.Id).ToList());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            IngredientsListBox.SelectedItems.Clear();
        }
    }
}
