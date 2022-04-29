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
        List<Halls> arrayHalls;
        public HallPage(int idHall)
        {
            InitializeComponent();
            arrayHalls = db.context.Halls.Where(x => x.IdHall == idHall).ToList();

        }
    }
}
