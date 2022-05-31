using Cinema.Model;
using Cinema.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для _EditFilmPage.xaml
    /// </summary>
    public partial class _EditFilmPage : Page
    {
        Core db = new Core();
        List<Films> arrayFilms;
        List<FilmsGenres> arrayFilmsGenres;
        List<Genres> arrayGenres;
        List<FilmsCountries> arrayFilmsCountries;
        List<Countries> arrayCountries;
        List<AgeLimits> arrayAgeLimits;
        List<int> arrayIdGenres = new List<int>();
        List<int> arrayIdCountries = new List<int>();
        string activeImage = "";
        int selectedIdFilm;
        string hoursDuration;
        string minuteDuration;
        int selectedTwoCountry = 0;
        int selectedTwoGenre = 0;
        public _EditFilmPage(int idFilm)
        {
            InitializeComponent();
            selectedIdFilm = idFilm;
            arrayFilms = db.context.Films.Where(x => x.IdFilm == idFilm).ToList();
            arrayFilmsGenres = db.context.FilmsGenres.Where(x => x.IdFilm == idFilm).ToList();
            arrayFilmsCountries = db.context.FilmsCountries.Where(x => x.IdFilm == idFilm).ToList();

            arrayAgeLimits = db.context.AgeLimits.ToList();
            AgeLimitComboBox.ItemsSource = arrayAgeLimits;
            AgeLimitComboBox.DisplayMemberPath = "Limit";
            AgeLimitComboBox.SelectedValuePath = "IdAgeLimit";

            arrayGenres = db.context.Genres.ToList();
            GenresComboBox.ItemsSource = arrayGenres;
            GenresComboBox.DisplayMemberPath = "NameGenre";
            GenresComboBox.SelectedValuePath = "IdGenre";

            GenresTwoComboBox.ItemsSource = arrayGenres;
            GenresTwoComboBox.DisplayMemberPath = "NameGenre";
            GenresTwoComboBox.SelectedValuePath = "IdGenre";

            arrayCountries = db.context.Countries.ToList();
            CountriesComboBox.ItemsSource = arrayCountries;
            CountriesComboBox.DisplayMemberPath = "NameCountry";
            CountriesComboBox.SelectedValuePath = "IdCountry";

            CountriesTwoComboBox.ItemsSource = arrayCountries;
            CountriesTwoComboBox.DisplayMemberPath = "NameCountry";
            CountriesTwoComboBox.SelectedValuePath = "IdCountry";

            foreach (var item in arrayFilms)
            {
                NameFilmTextBox.Text = item.NameFilm;
                DescriptionFilmTextBox.Text = item.DescriptionFilm;
                AgeLimitComboBox.SelectedValue = item.IdAgeLimit;
                ActorsTextBox.Text = item.Actors;
                FilmsCompanyTextBox.Text = item.FilmsCompany;
                FilmsDirectorsTextBox.Text = item.FilmsDirectors;
                PhotoPathTextBox.Text = item.PhotoPath;

                hoursDuration = Convert.ToString(item.Duration.Hours);
                minuteDuration = Convert.ToString(item.Duration.Minutes);
                DurationHoursFilmTextBox.Text = hoursDuration;
                DurationMinutesFilmTextBox.Text = minuteDuration;

            }
            foreach (var item in arrayFilmsCountries)
            {
                arrayIdCountries.Add(item.IdCountry);
            }
            if (arrayFilmsCountries.Count > 1)
            {
                CountriesTwoComboBox.Visibility = Visibility.Visible;
                AddCountryButton.Visibility = Visibility.Collapsed;
                DelCountryButton.Visibility = Visibility.Visible;
                CountriesComboBox.SelectedValue = arrayIdCountries[0];
                CountriesTwoComboBox.SelectedValue = arrayIdCountries[1];
            }
            else
            {
                foreach (var item in arrayFilmsCountries)
                {
                    CountriesComboBox.SelectedValue = item.IdCountry;
                }

            }


            foreach (var item in arrayFilmsGenres)
            {
                arrayIdGenres.Add(item.IdGenre);
            }
            if (arrayFilmsGenres.Count > 1)
            {
                GenresTwoComboBox.Visibility = Visibility.Visible;
                AddGenreButton.Visibility = Visibility.Collapsed;
                DelGenresButton.Visibility = Visibility.Visible;
                GenresComboBox.SelectedValue = arrayIdGenres[0];
                GenresTwoComboBox.SelectedValue = arrayIdGenres[1];
            }
            else
            {
                foreach (var item in arrayFilmsGenres)
                {
                    GenresComboBox.SelectedValue = item.IdGenre;
                }
                
            }

            
        }

        private void SelectPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog photoDialog = new OpenFileDialog();
            photoDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

            if (photoDialog.ShowDialog() == true)
            {
                string newfilename = "\\Assets\\Images\\Films\\";
                //путь к проекту
                string appFolderPath = Directory.GetCurrentDirectory();
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                string imageName = System.IO.Path.GetFileName(photoDialog.FileName);//имя картинки с расширением

                newfilename = appFolderPath + newfilename + imageName;

                File.Copy(photoDialog.FileName, newfilename);

                Console.WriteLine(newfilename);
                PhotoPathTextBox.Text = imageName;
                activeImage = imageName;
            }
        }


        private void AddCountryButtonClick(object sender, RoutedEventArgs e)
        {
            CountriesTwoComboBox.Visibility = Visibility.Visible;
            AddCountryButton.Visibility = Visibility.Collapsed;
            DelCountryButton.Visibility = Visibility.Visible;
        }


        private void DelCountryButtonClick(object sender, RoutedEventArgs e)
        {
            CountriesTwoComboBox.Visibility = Visibility.Collapsed;
            CountriesTwoComboBox.SelectedValue = null;
            AddCountryButton.Visibility = Visibility.Visible;
            DelCountryButton.Visibility = Visibility.Collapsed;
        }


        private void AddGenreButtonClick(object sender, RoutedEventArgs e)
        {
            GenresTwoComboBox.Visibility = Visibility.Visible;
            AddGenreButton.Visibility = Visibility.Collapsed;
            DelGenresButton.Visibility = Visibility.Visible;
        }

        private void DelGenresButtonClick(object sender, RoutedEventArgs e)
        {
            GenresTwoComboBox.Visibility = Visibility.Collapsed;
            GenresTwoComboBox.SelectedValue = null;
            AddGenreButton.Visibility = Visibility.Visible;
            DelGenresButton.Visibility = Visibility.Collapsed;
        }

        private void EditFilmButtonClick(object sender, RoutedEventArgs e)
        {
            try 
            { 
                int selectedAgeLimit = Convert.ToInt32(AgeLimitComboBox.SelectedValue);
                int selectedCountry = Convert.ToInt32(CountriesComboBox.SelectedValue);
                selectedTwoCountry = Convert.ToInt32(CountriesTwoComboBox.SelectedValue);
                int selectedGenre = Convert.ToInt32(GenresComboBox.SelectedValue);
                selectedTwoGenre = Convert.ToInt32(GenresTwoComboBox.SelectedValue);
                string nameFilm = NameFilmTextBox.Text;
                string actors = ActorsTextBox.Text;
                TimeSpan selectedDuration = new TimeSpan();
                FilmsViewModel newObject = new FilmsViewModel();
                bool result = newObject.CheckAddFilm(nameFilm, selectedAgeLimit, actors, DurationHoursFilmTextBox.Text, DurationMinutesFilmTextBox.Text, selectedCountry, selectedTwoCountry, selectedGenre, selectedTwoGenre);
                if (result)
                {
                    string description = DescriptionFilmTextBox.Text;
                    selectedDuration = new TimeSpan(Convert.ToInt32(DurationHoursFilmTextBox.Text), Convert.ToInt32(DurationMinutesFilmTextBox.Text), 0); ;

                    string filmsCompany = FilmsCompanyTextBox.Text;
                    string filmsDirector = FilmsDirectorsTextBox.Text;
                    string photoPath = PhotoPathTextBox.Text;
                    Console.WriteLine(selectedTwoGenre);
                    newObject.EditFilm(selectedIdFilm, nameFilm, description, selectedAgeLimit, selectedDuration, actors, filmsCompany, filmsDirector, photoPath, selectedCountry, selectedTwoCountry, selectedGenre, selectedTwoGenre);
                    MessageBox.Show("Вы успешно обновили данные о фильме. Возвращение на страницу фильма");
                    this.NavigationService.Navigate(new FilmPage(selectedIdFilm));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
