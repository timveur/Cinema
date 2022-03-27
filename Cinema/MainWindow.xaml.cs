using Cinema.View;
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

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HallPage());
            Console.WriteLine(Properties.Settings.Default.loginClient);
            

        }

        private void AuthButtonClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.loginClient))
            {
                MainFrame.Navigate(new AuthPage());
            }

        }

        



        /// <summary>
        /// выход из приложения
        /// </summary>
        private void WindowClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.loginClient = String.Empty;
            Properties.Settings.Default.Save();
        }

        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content;
        }


        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(Properties.Settings.Default.loginClient))
            {
                ExitButton.Visibility = Visibility.Collapsed;
                BackButton.Visibility = Visibility.Collapsed;
                AuthButton.Visibility = Visibility.Visible;
            }
            else
            {
                AuthButton.Visibility = Visibility.Collapsed;
                BackButton.Visibility = Visibility.Visible;
                ExitButton.Visibility = Visibility.Visible;
            }
        }

  
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageExit = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход...", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageExit == MessageBoxResult.Yes)
                {
                    Properties.Settings.Default.loginClient = String.Empty;
                    Properties.Settings.Default.Save();
                    MainFrame.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
