using Product.DataBase;
using Product.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Product
{
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
        }
        public ProductWindow(Users user)
        {
            InitializeComponent();
        }

        Pages.MateriaPages materialPages = new Pages.MateriaPages();
        Pages.SupplierPages supplierPages = new Pages.SupplierPages();

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(materialPages);
        }

        private void SuppliersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(supplierPages);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward) 
            {
                MainFrame.GoForward();
            }
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentSession.CurrentUser = null;
            new MainWindow().Show();    
            Close();
        }
    }
}
