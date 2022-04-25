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
        List<FilmsPhotos> arrayFilmsPhotos;
        //List<FilmsGenres> arrayFilmsGenres;
        //List<FilmsCountries> arrayFilmsCountries;
        DateTime selectDate = new DateTime();
        //string selectDate;
        public FilmPage(int idFilm)
        {
            InitializeComponent();
            arrayFilmsPhotos = db.context.FilmsPhotos.Where(x => x.IdFilm == idFilm).ToList();
            this.DataContext = arrayFilmsPhotos;

            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            var dayThreeLower = new StringBuilder(today.AddDays(2).ToString("dddd"));
            dayThreeLower[0] = char.ToUpper(dayThreeLower[0]);
            string dayThree = dayThreeLower.ToString();
            var dayFourLower = new StringBuilder(today.AddDays(3).ToString("dddd"));
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


            arraySessions = db.context.Sessions.Where(x => x.IdFilm == idFilm).ToList();
            SessionsListView.ItemsSource = arraySessions;

            

            //arrayFilmsGenres = db.context.FilmsGenres.Where(x => x.IdFilm == idFilm).ToList();
            //string allGenres = String.Join(",", arrayFilmsGenres);
            //GenresTextBlock.Text = allGenres;
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Страница в разработке.");
        }

        private void DateButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ScrollViewerMouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

  

        private void TodayButtonClick(object sender, RoutedEventArgs e)
        {
            DateTextBlock.Text = TodayTextBlock.Text;
        }

      
        
    }
}
