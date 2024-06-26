﻿using Cinema.Model;
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
using Word = Microsoft.Office.Interop.Word;

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
        List<int> arrayIdSeats = new List<int>();
        List<Tickets> arrayTicketsSelect;
        int idSelectedSeat = 0;
        string selectedSeatRow = "";
        Decimal costOneTicket = 0;
        Decimal costAllTickets = 0;
        int idSelectedSession;
        string costTickets = "0 руб.";
        public HallPage(int idSession)
        {
            InitializeComponent();
            idSelectedSession = idSession;
            arraySessions = db.context.Sessions.Where(x => x.IdSession == idSession).ToList();
            this.DataContext = arraySessions;
            string dateSession = "";
            string timeSession = "";

            foreach (var item in arraySessions)
            {
                dateSession = Convert.ToString((item.DateSession).ToString("d MMMM"));
                timeSession = Convert.ToString((item.StartTime).ToString(@"hh\:mm"));
                costOneTicket = item.CostTicket;
            }
            DateTimeTextBlock.Text = dateSession + " в " + timeSession;

            arrayTickets = db.context.Tickets.Where(x => x.IdSession == idSession).ToList();
            arrayRowSeats = db.context.Seats.Where(x => x.ParentId == 0).ToList();
            RowListView.ItemsSource = arrayRowSeats;         
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


        /// <summary>
        /// Убрать выбор места
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCheckUnchecked(object sender, RoutedEventArgs e)
        {
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
                if (itemSeat.ParentId != 0)
                {
                    idSeatRow = itemSeat.ParentId;
                }
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
            if (costAllTickets!=0)
            {
                costAllTickets -= costOneTicket;
            }
            costTickets = Convert.ToString(Convert.ToDouble(costAllTickets)) + " руб.";
            CostTextBlock.Text = costTickets;

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
            SelectedTextBlockUpdate();
            string numberRow = "";
            string numberSeat = "";
            int idSeatRow = 0;
            arraySeats = db.context.Seats.Where(x => x.IdSeat == idSelectedSeat).ToList();            
            foreach (var itemSeat in arraySeats)
            {
                arrayIdSeats.Add(itemSeat.IdSeat);
                numberSeat = itemSeat.NumberDescription;
                
                if (itemSeat.ParentId!=0)
                {
                    idSeatRow = itemSeat.ParentId;
                }
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
            costAllTickets += costOneTicket;
            costTickets = Convert.ToString(Convert.ToDouble(costAllTickets)) + " руб.";
            CostTextBlock.Text = costTickets;
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
            }

            if (arrayIdSeatsSelected.Count > 1)
            {
                SelectedTextBlock.Visibility = Visibility.Visible;
                SelectedSeatsTextBlock.Visibility = Visibility.Visible;
                SelectedTextBlock.Text = "Выбранные места: ";

            }
        }


        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                (sender as CheckBox).IsChecked = false;
            }
        }


        private void BuyTicketsButtonClick(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.idRoleClient == 0)
            {
                MessageBoxResult rez = MessageBox.Show($"Для покупки билетов необходимо авторизоваться.\nПерейти на страницу овторизации?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rez == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new AuthPage());
                }
            }
            if (Properties.Settings.Default.idRoleClient != 0)
            {
                try
                {
                    TicketsViewModel obj = new TicketsViewModel();
                    obj.AddTicket(idSelectedSession, arrayIdSeatsSelected);

                    
                    List<int> arrayIdTickets = new List<int>();
                    foreach (var item in arrayIdSeatsSelected)
                    {
                        arrayTicketsSelect = db.context.Tickets.Where(x => x.IdSeat == item).ToList();
                        foreach (var itemTicket in arrayTicketsSelect)
                        {
                            arrayIdTickets.Add(itemTicket.IdTicket);
                        }
                    }
                    if (arrayIdSeatsSelected.Count == 0)
                    {
                        MessageBox.Show("Покупка невозможна. Вы не выбрали места.");
                    }

                    if (arrayIdSeatsSelected.Count > 0)
                    {
                        var application = new Word.Application();
                        Word.Document document = application.Documents.Add();
                        document.PageSetup.PageWidth = 900;
                        document.PageSetup.PageHeight = 300;
                        Word.Paragraph tableParagraph = document.Paragraphs.Add();
                        Word.Range tableRange = tableParagraph.Range;
                        Word.Table infoTable = document.Tables.Add(tableRange, 5, 2);
                        infoTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        infoTable.TopPadding = 5;
                        infoTable.LeftPadding = 5;
                        Word.Range cellRange;
                        
                        cellRange = infoTable.Cell(1, 1).Range;
                        cellRange.Text = "Фильм: ";
                        cellRange.Font.Color = Word.WdColor.wdColorGray625;
                        cellRange = infoTable.Cell(1, 2).Range;
                        cellRange.Text = $"«{NameFilmTextBlock.Text}» ({AgeTextBlock.Text})";
                        cellRange = infoTable.Cell(2, 1).Range;
                        cellRange.Text = "Сеанс: ";
                        cellRange.Font.Color = Word.WdColor.wdColorGray625;
                        cellRange = infoTable.Cell(2, 2).Range;
                        cellRange.Text = DateTimeTextBlock.Text;
                        cellRange = infoTable.Cell(3, 1).Range;
                        cellRange.Text = "Места: ";
                        cellRange.Font.Color = Word.WdColor.wdColorGray625;
                        cellRange = infoTable.Cell(3, 2).Range;
                        if (arrayIdSeatsSelected.Count == 1)
                        {
                            cellRange.Text = String.Join(", ", arrayInfoSeatsSelected) + $" ({arrayIdSeatsSelected.Count} билет)";
                        }
                        if (arrayIdSeatsSelected.Count > 1 && arrayIdSeatsSelected.Count < 5)
                        {
                            cellRange.Text = String.Join(", ", arrayInfoSeatsSelected) + $" ({arrayIdSeatsSelected.Count} билета)";
                        }
                        if (arrayIdSeatsSelected.Count >= 5)
                        {
                            cellRange.Text = String.Join(", ", arrayInfoSeatsSelected) + $" ({arrayIdSeatsSelected.Count} билетов)";
                        }
                        cellRange = infoTable.Cell(4, 1).Range;
                        cellRange.Text = "Стоимость: ";
                        cellRange.Font.Color = Word.WdColor.wdColorGray625;
                        cellRange = infoTable.Cell(4, 2).Range;
                        cellRange.Text = CostTextBlock.Text;
                        cellRange = infoTable.Cell(5, 1).Range;
                        if (arrayIdSeatsSelected.Count == 1)
                        {
                            cellRange.Text = "Номер билета: ";
                            cellRange.Font.Color = Word.WdColor.wdColorGray625;
                        }
                        if (arrayIdSeatsSelected.Count > 1)
                        {
                            cellRange.Text = "Номера билетов: ";
                            cellRange.Font.Color = Word.WdColor.wdColorGray625;
                        }
                        string tickets = String.Join(", ", arrayIdTickets);
                        cellRange = infoTable.Cell(5, 2).Range;
                        cellRange.Text = tickets;
                        infoTable.Columns[1].Width = 65;
                        infoTable.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray20;
                        string newfilename = "\\Assets\\Other\\";
                        //путь к проекту
                        string appFolderPath = System.Environment.CurrentDirectory;

                        document.SaveAs2($"{appFolderPath}{newfilename}Ticket.pdf", Word.WdExportFormat.wdExportFormatPDF);
                        application.Visible = true;
                        MessageBoxResult rez = MessageBox.Show("Хотите распечатать билет?", "Печать билета", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (rez == MessageBoxResult.Yes)
                        {
                            PrintDialog printObj = new PrintDialog();
                            if (printObj.ShowDialog() == true)
                            {
                                document.PrintOut();
                            }
                            else
                            {
                                MessageBox.Show("Пользователь прервал печать", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        MessageBox.Show("Билеты куплены.\nВозвращение на главную страницу.");
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
}
