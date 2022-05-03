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
    /// Логика взаимодействия для HallPage.xaml
    /// </summary>
    public partial class HallPage : Page
    {
        Core db = new Core();
        List<Sessions> arraySessions;
        List<HallsSeats> arrayHallsSeats;
        int idHall;
        public HallPage(int idSession)
        {
            InitializeComponent();
            arraySessions = db.context.Sessions.Where(x => x.IdSession == idSession).ToList();
            this.DataContext = arraySessions;
            string dateSession = "";
            string timeSession = "";
            
            foreach (var item in arraySessions)
            {
                dateSession = Convert.ToString((item.DateSession).ToString("d MMMM"));
                timeSession = Convert.ToString((item.StartTime).ToString(@"hh\:mm"));
                idHall = item.IdHall;
            }
            DateTimeTextBlock.Text = dateSession + " в " + timeSession;

            arrayHallsSeats = db.context.HallsSeats.Where(x => x.IdHall == idHall).ToList();
            SessionsListBox.ItemsSource = arrayHallsSeats;
            
        }
    }
}
