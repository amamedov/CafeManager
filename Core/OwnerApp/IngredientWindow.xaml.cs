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
    /// Логика взаимодействия для IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        OwnerService service;
        public IngredientWindow(OwnerService service)
        {
            InitializeComponent();
            this.service = service;
            IngredientsListBox.ItemsSource = service.GetAll<Ingredient>().Select(s => s.Name);
        }

        private void ViewInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsListBox.SelectedItem != null)
            {
                var ingredient = service.GetAll<Ingredient>().First(i => i.Name == IngredientsListBox.SelectedItem.ToString());
                MessageBox.Show($"Quantity of {ingredient.Name} in storage : {ingredient.QuantityInStorage} {ingredient.Measurement}s");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
