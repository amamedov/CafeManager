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
    /// Логика взаимодействия для ProfitWindow.xaml
    /// </summary>
    public partial class ProfitWindow : Window
    {
        OwnerService service;
        public ProfitWindow(OwnerService service)
        {
            InitializeComponent();
            this.service = service;
            ProfitListBox.ItemsSource = service.GetAll<Transaction>().Select(i => i.Id);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProfitListBox.SelectedItem != null)
            {
                var transaction = service.GetTransaction(int.Parse(ProfitListBox.SelectedIndex.ToString()));
                MessageBox.Show($"Transaction: {transaction.Id}, Time: {transaction.Time}, Amount: {transaction.Amount}");
            }
        }
    }
}
