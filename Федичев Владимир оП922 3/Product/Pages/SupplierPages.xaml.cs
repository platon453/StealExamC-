using Product.DataBase;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Product.Pages
{
    /// <summary>
    /// Логика взаимодействия для SupplierPages.xaml
    /// </summary>
    public partial class SupplierPages : Page
    {
        private VANYAKRUTOIEntities _db = new VANYAKRUTOIEntities();
        public SupplierPages()
        {
            InitializeComponent();
            LoadSuppliers();
        }
        public void LoadSuppliers()
        {
            SupplierlList.ItemsSource = _db.Suppliers.ToList();
        }
    }
}
