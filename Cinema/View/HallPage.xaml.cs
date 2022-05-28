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
    /// Логика взаимодействия для HallPage.xaml
    /// </summary>
    public partial class HallPage : Page
    {
        Core db = new Core();
        List<Sessions> arraySessions;
        List<Seats> arraySeats;
        List<Seats> arrayRowSeats;
        List<Tickets> arrayTickets;
        List<int> rows = new List<int>();
        List<int> arrayIdSeatsSelected = new List<int>();
        List<string> arrayInfoSeatsSelected = new List<string>();
        
        string[] rowsNotRepeat;
        int idSelectedSeat = 0;
        string selectedSeatRow = "";
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
            }
            DateTimeTextBlock.Text = dateSession + " в " + timeSession;

            arrayTickets = db.context.Tickets.Where(x => x.IdSession == idSession).ToList();
            arrayRowSeats = db.context.Seats.Where(x => x.ParentId == 0).ToList();
            RowListView.ItemsSource = arrayRowSeats;

           
            //SessionsListBox.ItemsSource = arrayHallsSeats;

            //SessionsListView.ItemsSource = HallBoxSource.FillBoxNodeList(0);

            foreach (var item in arrayRowSeats)
            {
                int row = item.IdSeat;
                if (!rows.Contains(row))
                {
                    rows.Add(row);
                }
            }
            int rowSeat = 0;

            rowSeat = rows[0];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();

            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat==Convert.ToInt32(newCheckBox.DataContext))
                    {
                        
                        newCheckBox.IsEnabled = false ;
                        
                    }
                }
                OneRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[1];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                TwoRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[2];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                ThreeRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[3];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                FourRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[4];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };

                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                FiveRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[5];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };

                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                SixRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[6];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };

                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                SevenRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[7];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };

                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                EightRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[8];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                NineRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[9];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                TenRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[10];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                ElevenRowStackPanel.Children.Add(newCheckBox);

            }
            rowSeat = rows[11];
            arraySeats = db.context.Seats.Where(x => x.ParentId == rowSeat).ToList();
            foreach (var item in arraySeats)
            {

                CheckBox newCheckBox = new CheckBox
                {
                    Content = item.Number,
                    DataContext = item.IdSeat
                };
                newCheckBox.FontSize = 8;
                newCheckBox.Margin = new Thickness(5, 0, 5, 0);
                newCheckBox.Checked += NewCheckChecked;
                newCheckBox.Unchecked += NewCheckUnchecked;
                newCheckBox.Background = Brushes.Yellow;
                foreach (var itemTicket in arrayTickets)
                {
                    if (itemTicket.IdSeat == Convert.ToInt32(newCheckBox.DataContext))
                    {

                        newCheckBox.IsEnabled = false;

                    }
                }
                TwelveRowStackPanel.Children.Add(newCheckBox);

            }

        }



        private void DisplayInfo()
        {

        }

        /// <summary>
        /// Убрать выбор места
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCheckUnchecked(object sender, RoutedEventArgs e)
        {
            DisplayInfo();
            CheckBox unactiveCheck = sender as CheckBox;
            idSelectedSeat = Convert.ToInt32(unactiveCheck.DataContext);
            arrayIdSeatsSelected.Remove(idSelectedSeat);

            string numberRow = "";
            string numberSeat = "";
            int idSeatRow = 0;

            arraySeats = db.context.Seats.Where(x => x.IdSeat == idSelectedSeat).ToList();


            foreach (var itemSeat in arraySeats)
            {

                numberSeat = itemSeat.NumberDescription;
                idSeatRow = itemSeat.ParentId ?? 0;
                arrayRowSeats = db.context.Seats.Where(x => x.IdSeat == idSeatRow).ToList();
                foreach (var itemRow in arrayRowSeats)
                {

                    numberRow = itemRow.NumberDescription;


                }

            }
            Console.WriteLine(numberSeat);
            Console.WriteLine(numberRow);
            selectedSeatRow = numberRow + " " + numberSeat;
            arrayInfoSeatsSelected.Remove(selectedSeatRow);
            SelectedSeatsTextBlock.Text = String.Join(", ", arrayInfoSeatsSelected);
            if (arrayInfoSeatsSelected.Count() == 0)
            {
                SelectedTextBlock.Visibility = Visibility.Collapsed;
                SelectedSeatsTextBlock.Visibility = Visibility.Collapsed;
            }

        }

        /// <summary>
        /// Добавить выбор места
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCheckChecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheck = sender as CheckBox;
            idSelectedSeat = Convert.ToInt32(activeCheck.DataContext);
            arrayIdSeatsSelected.Add(idSelectedSeat);
            Console.WriteLine(idSelectedSeat);
            //arrGenres.Add(activeCheck.Content.ToString());

            SelectedTextBlockUpdate();

            string numberRow = "";
            string numberSeat = "";
            int idSeatRow = 0;

            arraySeats = db.context.Seats.Where(x => x.IdSeat == idSelectedSeat).ToList();

            
            foreach (var itemSeat in arraySeats)
            {
                    
                numberSeat = itemSeat.NumberDescription;
                idSeatRow = itemSeat.ParentId ?? 0;
                arrayRowSeats = db.context.Seats.Where(x => x.IdSeat == idSeatRow).ToList();
                foreach (var itemRow in arrayRowSeats)
                {
                   
                    numberRow = itemRow.NumberDescription;
                   
                    
                }
                
            }
            Console.WriteLine(numberSeat);
            Console.WriteLine(numberRow);
            selectedSeatRow = numberRow + " " + numberSeat;
            arrayInfoSeatsSelected.Add(selectedSeatRow);


            SelectedSeatsTextBlock.Text = String.Join(", ", arrayInfoSeatsSelected);

        }


        private void SelectedTextBlockUpdate()
        {
            if (arrayIdSeatsSelected == null)
            {
                SelectedTextBlock.Visibility = Visibility.Collapsed;
                SelectedSeatsTextBlock.Visibility = Visibility.Collapsed;
            }
            if (arrayIdSeatsSelected.Count == 1)
            {
                SelectedTextBlock.Visibility = Visibility.Visible;
                SelectedSeatsTextBlock.Visibility = Visibility.Visible;
                SelectedTextBlock.Text = "Выбранное место: ";
               // SelectedSeatsTextBlock.Text += selectedSeatRow;
            }

            if (arrayIdSeatsSelected.Count > 1)
            {
                SelectedTextBlock.Visibility = Visibility.Visible;
                SelectedSeatsTextBlock.Visibility = Visibility.Visible;
                SelectedTextBlock.Text = "Выбранные места: ";
               // SelectedSeatsTextBlock.Text += ", " + selectedSeatRow;

            }
        }


       
        
    }
}
