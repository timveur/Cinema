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

        List<Halls> arrayHalls;
        List<Formats> arrayFormats;
        List<Films> arrayFilms;
        TimeSpan duration;
        int selectedIdFilm;
        public _AddSessionPage(int idFilm)
        {
            InitializeComponent();

            arrayHalls = db.context.Halls.ToList();
            HallsComboBox.ItemsSource = arrayHalls;
            HallsComboBox.DisplayMemberPath = "NameHall";
            HallsComboBox.SelectedValuePath = "IdHall";

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

                int selectedHall = Convert.ToInt32(HallsComboBox.SelectedValue);
                int selectedFormat = Convert.ToInt32(FormatsComboBox.SelectedValue);
                TimeSpan startTime = TimeSpan.Parse(StartTimeTextBox.Text);
                TimeSpan endTime = startTime + duration;
                SessionsViewModel newObject = new SessionsViewModel();
                bool result = newObject.AddSession(selectedHall, selectedFormat, DateSessionDatePicker.Text, StartTimeTextBox.Text, CostTextBox.Text);
                if (result)
                {
                    Sessions newSession = new Sessions()
                    {
                        IdFilm = selectedIdFilm,
                        IdHall = selectedHall,
                        IdFormat = selectedFormat,
                        DateSession = Convert.ToDateTime(DateSessionDatePicker.Text),
                        StartTime = startTime,
                        EndTime = endTime,
                        CostTicket = Decimal.Parse(CostTextBox.Text)
                    };
                    db.context.Sessions.Add(newSession);
                    db.context.SaveChanges();
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
