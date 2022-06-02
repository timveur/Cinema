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
    /// Логика взаимодействия для _AddFilmPage.xaml
    /// </summary>
    public partial class _AddFilmPage : Page
    {
        Core db = new Core();
        
        List<AgeLimits> arrayAgeLimits;
        List<Genres> arrayGenres;
        List<Countries> arrayCountries;
        string activeImage = "";
        int selectedTwoCountry = 0;
        int selectedTwoGenre = 0;
        public _AddFilmPage()
        {
            InitializeComponent();

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

            activeImage = PhotoPathTextBox.Text;
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

        private void AddFilmButtonClick(object sender, RoutedEventArgs e)
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
                    newObject.AddFilm(nameFilm, description, selectedAgeLimit, selectedDuration, actors, filmsCompany, filmsDirector, photoPath, selectedCountry, selectedTwoCountry, selectedGenre, selectedTwoGenre);
                    MessageBox.Show("Вы успешно добавили фильм. Возвращение к списку фильмов.");
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
