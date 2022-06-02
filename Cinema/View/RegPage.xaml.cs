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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string patronymic = PatronymicTextBox.Text;
                string login = LoginTextBox.Text;
                string email = EmailTextBox.Text;
                string password = PassPasswordBox.Password;
                string repeatPassword = RepeatPasswordBox.Password;
                string phone = PhoneTextBox.Text;                
                UsersViewModel newObject = new UsersViewModel();
                bool result = newObject.CheckRegUser(lastName, firstName, login, email, password, repeatPassword);
                if (result)
                {
                    newObject.AddUser(lastName, firstName, patronymic, login, email, password, phone);
                    MessageBox.Show("Вы успешно зарегистрировлаись. Возвращение на страницу авторизации.");
                    this.NavigationService.Navigate(new AuthPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
