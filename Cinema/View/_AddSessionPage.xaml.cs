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
    /// Логика взаимодействия для _AddSessionPage.xaml
    /// </summary>
    public partial class _AddSessionPage : Page
    {
        Core db = new Core(); 
        List<Formats> arrayFormats;
        List<Films> arrayFilms;
        TimeSpan duration;
        int selectedIdFilm;
        public _AddSessionPage(int idFilm)
        {
            InitializeComponent();
            arrayFormats = db.context.Formats.ToList();
            FormatsComboBox.ItemsSource = arrayFormats;
            FormatsComboBox.DisplayMemberPath = "Format";
            FormatsComboBox.SelectedValuePath = "IdFormat";
            arrayFilms = db.context.Films.Where(x=>x.IdFilm==idFilm).ToList();
            foreach (var item in arrayFilms)
            {
                duration = item.Duration;
            }
            selectedIdFilm = idFilm;
        }


        private void AddSessionButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedFormat = Convert.ToInt32(FormatsComboBox.SelectedValue);
                TimeSpan startTime = TimeSpan.Parse(StartTimeTextBox.Text);
                TimeSpan endTime = startTime + duration;
                DateTime dateSession = Convert.ToDateTime(DateSessionDatePicker.Text);
                Decimal costTicket = Decimal.Parse(CostTextBox.Text);
                SessionsViewModel newObject = new SessionsViewModel();
                bool result = newObject.CheckAddSession(selectedFormat, DateSessionDatePicker.Text, StartTimeTextBox.Text, CostTextBox.Text);
                if (result)
                {
                    newObject.AddSession(selectedIdFilm, selectedIdFilm, dateSession, startTime, endTime, costTicket);
                    MessageBox.Show("Вы успешно добавили сеанс. Возвращение к странице фильма.");
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
