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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Core db = new Core();
        List<Films> arrayFilms;
        List<string> arrayAllGenres = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            arrayFilms = db.context.Films.ToList();
            FilmsListView.ItemsSource = arrayFilms;
            if (Properties.Settings.Default.idRoleClient == 1)
            {
                AddButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
                int idFilm = 0;
            foreach (var item in arrayFilms)
            {
                idFilm = item.IdFilm;
            }
            
        }



        private void FilmPreviewImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image activeElement = sender as Image;
            Films activeFilmsPhotos = activeElement.DataContext as Films;
            int idFilm = activeFilmsPhotos.IdFilm;
            this.NavigationService.Navigate(new FilmPage(idFilm));
        }


        private void NameFilmTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock activeElement = sender as TextBlock;
          
            Films activeFilmsPhotos = activeElement.DataContext as Films;
            
            int idFilm = activeFilmsPhotos.IdFilm;
            if (DeleteModeTextBlock.Visibility == Visibility.Visible)
            {
                Films objFilms = activeElement.DataContext as Films;
                MessageBoxResult rez = MessageBox.Show($"Удалить \"{activeElement.Text}\"?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rez == MessageBoxResult.Yes)
                {
                    FilmsViewModel newObj = new FilmsViewModel();
                    newObj.DeleteFilm(objFilms);
                    MessageBox.Show("Данные успешно удалены.\nВозвращение на главную страницу", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new MainPage());
                }
                FilmsListView.ItemsSource = arrayFilms;
                DeleteModeTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.NavigationService.Navigate(new FilmPage(idFilm));
            }
            
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new _AddFilmPage());
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            DeleteButton.Visibility = Visibility.Collapsed;
            DeleteModeTextBlock.Visibility = Visibility.Visible;
            ReturnButton.Visibility = Visibility.Visible;
        }

        private void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            DeleteModeTextBlock.Visibility = Visibility.Collapsed;
            ReturnButton.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Visible;
        }

    

        private void SessionsButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeElement = sender as Button;
            Films activeFilmsPhotos = activeElement.DataContext as Films;
            int idFilm = activeFilmsPhotos.IdFilm;
            this.NavigationService.Navigate(new FilmPage(idFilm));
        }
    }
}
