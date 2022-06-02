using Cinema.Model;
using Cinema.ViewModel;
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

namespace Cinema.View
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        List<Users> arrayUsers;
        public AuthPage()
        {
            InitializeComponent();

        }


        private void RegTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }

     
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckClass newObject = new CheckClass();
                bool result = newObject.CheckAuth(LoginTextBox.Text, AuthPasswordBox.Password);
                if (result)
                {
                    Properties.Settings.Default.loginClient = LoginTextBox.Text;
                    arrayUsers = db.context.Users.Where(x=>x.Login==LoginTextBox.Text).ToList();
                    foreach (var item in arrayUsers)
                    {
                        Properties.Settings.Default.idRoleClient = item.IdRole;
                    }
                    
                    Properties.Settings.Default.Save();

                    this.NavigationService.Navigate(new MainPage());
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
