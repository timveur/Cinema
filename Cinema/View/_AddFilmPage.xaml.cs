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
        public _AddFilmPage()
        {
            InitializeComponent();

            

            arrayAgeLimits = db.context.AgeLimits.ToList();
            

            AgeLimitComboBox.ItemsSource = arrayAgeLimits;

            AgeLimitComboBox.DisplayMemberPath = "Limit";
            AgeLimitComboBox.SelectedValuePath = "IdAgeLimit";

            arrayGenres = db.context.Genres.ToList();
            foreach (var item in arrayGenres)
            {
                CheckBox newCheckGenre = new CheckBox
                {
                    Content = item.NameGenre,
                };

                
                GenresStackPanelComboBox.Children.Add(newCheckGenre);

            }

            arrayCountries = db.context.Countries.ToList();
            foreach (var item in arrayCountries)
            {
                CheckBox newCheckCountry = new CheckBox
                {
                    Content = item.NameCountry
                };

                CountriesStackPanelComboBox.Children.Add(newCheckCountry);

            }
            activeImage = PhotoPathTextBox.Text;
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
                TimeSpan selectedDuration = new TimeSpan();
                FilmsViewModel newObject = new FilmsViewModel();
                bool result = newObject.AddFilm(NameFilmTextBox.Text, selectedAgeLimit, ActorsTextBox.Text);
                bool resultDuration = newObject.AddFilmCheckDuration(DurationHoursFilmTextBox.Text, DurationMinutesFilmTextBox.Text);
                if (resultDuration)
                {
                    selectedDuration = new TimeSpan(Convert.ToInt32(DurationHoursFilmTextBox.Text), Convert.ToInt32(DurationMinutesFilmTextBox.Text), 0);
                }

                if (result && resultDuration)
                {
                    Films newFilm = new Films()
                    {
                        NameFilm = NameFilmTextBox.Text,
                        DescriptionFilm = DescriptionFilmTextBox.Text,
                        IdAgeLimit = selectedAgeLimit,
                        Duration = selectedDuration,
                        Actors = ActorsTextBox.Text,
                        FilmsCompany = FilmsCompanyTextBox.Text,
                        FilmsDirectors = FilmsDirectorsTextBox.Text
                    };
                    db.context.Films.Add(newFilm);
                    db.context.SaveChanges();
                    Console.WriteLine(newFilm.IdFilm);
                    FilmsPhotos newFilmPhotos = new FilmsPhotos()
                    {
                        IdFilm = newFilm.IdFilm,
                        PhotoPath = (activeImage != "") ? activeImage : "_nonephoto.jpg"
                    };
                db.context.FilmsPhotos.Add(newFilmPhotos);
                db.context.SaveChanges();
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
