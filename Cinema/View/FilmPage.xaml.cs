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
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        Core db = new Core();
        List<Sessions> arraySessions;
        List<Films> arrayFilms;
        List<FilmsGenres> arrayFilmsGenres;
        List<FilmsCountries> arrayFilmsCountries;
        List<string> arrayAllGenres = new List<string>();
        List<string> arrayAllCountries = new List<string>();
        DateTime selectDate = new DateTime(1, 1, 1);
        int selectedIdFilm;
        DateTime today = new DateTime();
        DateTime tomorrow = new DateTime();
        DateTime dayThreeDate = new DateTime();
        DateTime dayFourDate = new DateTime();
        BrushConverter bc = new BrushConverter();
        public FilmPage(int idFilm)
        {
            InitializeComponent();
            if (Properties.Settings.Default.idRoleClient == 1)
            {
                AddSessionButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
            }
            selectedIdFilm = idFilm;
            arrayFilms = db.context.Films.Where(x => x.IdFilm == idFilm).ToList();
            this.DataContext = arrayFilms;
            today = DateTime.Today;
            tomorrow = today.AddDays(1);
            dayThreeDate = today.AddDays(2);
            dayFourDate = today.AddDays(3);
            var dayThreeLower = new StringBuilder(dayThreeDate.ToString("dddd"));
            dayThreeLower[0] = char.ToUpper(dayThreeLower[0]);
            string dayThree = dayThreeLower.ToString();
            var dayFourLower = new StringBuilder(dayFourDate.ToString("dddd"));
            dayFourLower[0] = char.ToUpper(dayFourLower[0]);
            string dayFour = dayFourLower.ToString();           
            TodayTextBlock.Text = "Сегодня";
            TodayDateTextBlock.Text = today.ToString("d MMMM");
            TomorrowTextBlock.Text = "Завтра";
            TomorrowDateTextBlock.Text = tomorrow.ToString("d MMMM");
            DayThreeTextBlock.Text = dayThree;
            DayThreeDateTextBlock.Text = today.AddDays(2).ToString("d MMMM");
            DayFourTextBlock.Text = dayFour;
            DayFourDateTextBlock.Text = today.AddDays(3).ToString("d MMMM");
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == idFilm).Where(y=>y.DateSession == today).OrderBy(ob => ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;
            arrayFilmsGenres = db.context.FilmsGenres.Where(x => x.IdFilm == idFilm).ToList();
            foreach (var item in arrayFilmsGenres)
            {
                arrayAllGenres.Add(item.Genres.NameGenre);
            }
            string allGenres = String.Join(", ", arrayAllGenres);
            GenresTextBlock.Text = allGenres;
            arrayFilmsCountries = db.context.FilmsCountries.Where(x => x.IdFilm == idFilm).ToList();
            foreach (var item in arrayFilmsCountries)
            {
                Console.WriteLine(item.Countries.NameCountry);
                arrayAllCountries.Add(item.Countries.NameCountry);                
            }
            string allCountries = String.Join(", ", arrayAllCountries);
            CountriesTextBlock.Text = allCountries;
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new _EditFilmPage(selectedIdFilm));
        }
      

        private void AddSessionButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new _AddSessionPage(selectedIdFilm));
        }

            

        private void SessionButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeElement = sender as Button;
            Sessions activeSession = activeElement.DataContext as Sessions;
            int idSession = activeSession.IdSession;
            this.NavigationService.Navigate(new HallPage(idSession));
        }


        private void TodayButtonClick(object sender, RoutedEventArgs e)
        {
            TodayButton.Background = (Brush)bc.ConvertFrom("#8768A8");
            TomorrowButton.Background = Brushes.Transparent;
            DayThreeButton.Background = Brushes.Transparent;
            DayFourButton.Background = Brushes.Transparent;
            DateButton.Background = Brushes.Transparent;
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == selectedIdFilm).Where(y => y.DateSession == today).OrderBy(ob => ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;
        }

        private void TomorrowButtonClick(object sender, RoutedEventArgs e)
        {
            TomorrowButton.Background = (Brush)bc.ConvertFrom("#8768A8");
            TodayButton.Background = Brushes.Transparent;
            DayThreeButton.Background = Brushes.Transparent;
            DayFourButton.Background = Brushes.Transparent;
            DateButton.Background = Brushes.Transparent;
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == selectedIdFilm).Where(y => y.DateSession == tomorrow).OrderBy(ob => ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;
        }


        private void DayThreeButtonClick(object sender, RoutedEventArgs e)
        {
            DayThreeButton.Background = (Brush)bc.ConvertFrom("#8768A8");
            TodayButton.Background = Brushes.Transparent;
            TomorrowButton.Background = Brushes.Transparent;
            DayFourButton.Background = Brushes.Transparent;
            DateButton.Background = Brushes.Transparent;
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == selectedIdFilm).Where(y => y.DateSession == dayThreeDate).OrderBy(ob => ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;
        }

        private void DayFourButtonClick(object sender, RoutedEventArgs e)
        {
            DayFourButton.Background = (Brush)bc.ConvertFrom("#8768A8");
            TodayButton.Background = Brushes.Transparent;
            TomorrowButton.Background = Brushes.Transparent;
            DayThreeButton.Background = Brushes.Transparent;
            DateButton.Background = Brushes.Transparent;
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == selectedIdFilm).Where(y => y.DateSession == dayFourDate).OrderBy(ob=>ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;
        }


        private void PickDatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateButton.Background = (Brush)bc.ConvertFrom("#8768A8");
            TodayButton.Background = Brushes.Transparent;
            TomorrowButton.Background = Brushes.Transparent;
            DayThreeButton.Background = Brushes.Transparent;
            DayFourButton.Background = Brushes.Transparent;
            DateTextBlock.Text = PickDatePicker.SelectedDate.Value.ToString("dd MMMM");
            selectDate = PickDatePicker.SelectedDate.Value;
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == selectedIdFilm).Where(y => y.DateSession == selectDate).OrderBy(ob => ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;
        }

        private void DateButtonClick(object sender, RoutedEventArgs e)
        {  
            DateButton.Background = (Brush)bc.ConvertFrom("#8768A8");
            TodayButton.Background = Brushes.Transparent;
            TomorrowButton.Background = Brushes.Transparent;
            DayThreeButton.Background = Brushes.Transparent;
            DayFourButton.Background = Brushes.Transparent;
            arraySessions = db.context.Sessions.Where(x => x.IdFilm == selectedIdFilm).Where(y => y.DateSession == selectDate).OrderBy(ob => ob.StartTime).ToList();
            SessionsListView.ItemsSource = arraySessions;       
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {
                printObj.PrintVisual(SessionsListView, "");
            }
            else
            {
                MessageBox.Show("Пользователь прервал печать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
