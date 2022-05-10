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
        List<HallsSeats> arraySeats;
        int idHall;
        List<int> rows = new List<int>();
        List<int> seats = new List<int>();
        string[] rowsNotRepeat;
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
            //SessionsListBox.ItemsSource = arrayHallsSeats;

           
            StackPanel newStackPanel = new StackPanel();
            newStackPanel.Orientation = Orientation.Horizontal;
            
            
            int row = 0;
            foreach (var item in arrayHallsSeats)
            {
                ListViewItem lvi = new ListViewItem();
                row = item.Row;
                if (!rows.Contains(row))
                {
                    
                   
                
                    rows.Add(row);
                    TextBlock newTextBlock = new TextBlock
                    {
                        Text = row + " ряд"
                    };
                    newTextBlock.Width = 150;
                    newStackPanel.Children.Add(newTextBlock);
                    arraySeats = db.context.HallsSeats.Where(x => x.IdHall == idHall).Where(x=>x.Row==row).ToList();
                    //newStackPanel.Children.Add(newTextBlock);
                    foreach (var itemSeat in arraySeats)
                    {
                        CheckBox newCheck = new CheckBox
                        {
                            Content = itemSeat.NumberSeat,
                        };
                        newCheck.Margin = new Thickness(5, 0, 5, 0);

                        //newCheck.Checked += NewCheckChecked;
                        //newCheck.Unchecked += NewCheckUnchecked;
                        newStackPanel.Children.Add(newCheck);
                        //SessionsListBox.Items.Add(newCheck);
                    }
                  
                    lvi.Content = newStackPanel;
                    SessionsListView.Items.Add(lvi);

                    
                }
                
                 

            }

           


        }
    }
}
