using Product.DataBase;
using Product.Helpers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Product
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ProductDBFedEntities _db = new ProductDBFedEntities();
        private VANYAKRUTOIEntities _db = new VANYAKRUTOIEntities();
        private MessageHelper _mh = new MessageHelper();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new ProductWindow().Show();
            Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginEnter.Text;
            var password = PasswordEnter.Password;

            var user = _db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            if(user == null)
            {
                _mh.ShowError("Введён неправильный логин или пароль");
            }
            else
            {
                CurrentSession.CurrentUser = user;
                new ProductWindow(user).Show();
                Close();
            }
            
        }
    }
}
