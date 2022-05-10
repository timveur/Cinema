using Cinema.Model;
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
        List<Sessions> arraySessions;
        List<FilmsPhotos> arrayFilms;
        List<Genres> arrayGenres;
        List<FilmsGenres> arrayFilmsGenres;
        List<string> arrayAllGenres = new List<string>();
        FilmsPhotos annVlad;
        List<string> arrGenres;
        public MainPage()
        {
            InitializeComponent();
            //var result = from Genres in db.context.Genres
            //             join FilmsGenres in db.context.FilmsGenres on Genres.IdGenre equals FilmsGenres.IdGenre

            //             select new
            //             {
            //                 nameGenre = Genres.NameGenre,
            //                 nameFilm = FilmsGenres.Films.NameFilm,



            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.nameGenre);
            //}

           


            //arrayFilms = db.context.Films.ToList();
            //foreach (var item in arrayFilms)
            //{
            //    TextBlock newImage = new TextBlock
            //    {
            //        Text= item.NameFilm
            //    };
            //    MainStackPanel.Children.Add(newImage);

            //}

            arrayFilms = db.context.FilmsPhotos.ToList();
            FilmsListView.ItemsSource = arrayFilms;
            arraySessions = db.context.Sessions.ToList();


            int idFilm = 0;
            foreach (var item in arrayFilms)
            {
                idFilm = item.IdFilm;
            }

            arrayGenres = db.context.Genres.ToList();
            arrayFilmsGenres = db.context.FilmsGenres.Where(x => x.IdFilm == idFilm).ToList();
            foreach (var item in arrayFilmsGenres)
            {
                arrayAllGenres.Add(item.Genres.NameGenre);
            }
            string allGenres = String.Join(", ", arrayAllGenres);

            

            foreach (MainPage obj in FilmsListView.Items.OfType<MainPage>())
            {
                
            }

            foreach (var item in arrayGenres)
            {
                CheckBox newCheck = new CheckBox
                {
                    Content = item.NameGenre
                };
                newCheck.Checked += NewCheckChecked;
                newCheck.Unchecked += NewCheckUnchecked;
                GenresStackPanelComboBox.Children.Add(newCheck);

            }
            


        }

        
        private void DisplayInfo()
        {
            
        }

        /// <summary>
        /// Отключение выбора жанра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCheckUnchecked(object sender, RoutedEventArgs e)
        {
            DisplayInfo();
        }

        /// <summary>
        /// Включение выбора жанра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCheckChecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheck = sender as CheckBox;
            arrGenres.Add(activeCheck.Content.ToString());

        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Страница в разработке.");
        }

      
        private void ScrollViewerMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }


        private void FilmPreviewImageMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image activeElement = sender as Image;
            FilmsPhotos activeFilmsPhotos = activeElement.DataContext as FilmsPhotos;
            int idFilm = activeFilmsPhotos.IdFilm;
            this.NavigationService.Navigate(new FilmPage(idFilm));
        }


        private void NameFilmTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock activeElement = sender as TextBlock;
          
            FilmsPhotos activeFilmsPhotos = activeElement.DataContext as FilmsPhotos;
            
            int idFilm = activeFilmsPhotos.IdFilm;
            if (DeleteModeTextBlock.Visibility == Visibility.Visible)
            {
                Films objFilms = activeElement.DataContext as Films;
               
               // FilmsPhotos objFilmsPhotos = activeElement.DataContext as FilmsPhotos;
                //Films activeFilm = db.context.Films.Where(x => x.IdFilm == idFilm) as Films;
                MessageBoxResult rez = MessageBox.Show($"Удалить \"{activeElement.Text}\"?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rez == MessageBoxResult.Yes)
                {
                   
                   // db.context.Films.Remove(activeFilm);
                    db.context.Films.Remove(objFilms);
                   
                    db.context.SaveChanges();
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
            Console.WriteLine(annVlad.IdFilm);
            DeleteModeTextBlock.Visibility = Visibility.Collapsed;
            ReturnButton.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Visible;
        }

        //private void FilmsListView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
            
        //     annVlad = FilmsListView.SelectedItem as FilmsPhotos;
        //    Console.WriteLine(annVlad.IdFilm);
        //}
    }
}
