using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    public class TicketsViewModel
    {
        private static Core db = new Core();

        public void AddTicket(int idSession, List<int> arrayIdSeats)
        {
            foreach (var item in arrayIdSeats)
            {
                Tickets newTicket = new Tickets()
                {
                    IdSession = idSession,
                    IdSeat = item,
                    IdUser = Properties.Settings.Default.idClient
                };
                db.context.Tickets.Add(newTicket);
            }
            db.context.SaveChanges();
        }


        /////////////////////////////////// For Tests /////////////////////////////////////

        public bool AddTicketTest(int idSession, List<int> arrayIdSeats)
        {
            List<Tickets> countRecords = new List<Tickets>();
            foreach (var item in arrayIdSeats)
            {
                Tickets newTicket = new Tickets()
                {
                    IdSession = idSession,
                    IdSeat = item,
                    IdUser = 1
                };
                db.context.Tickets.Add(newTicket);
                db.context.SaveChanges();
                countRecords.Add(newTicket);
                
            }
            db.context.SaveChanges();
            if (countRecords.Count() == arrayIdSeats.Count())
            {
                foreach (var item in countRecords)
                {
                    db.context.Tickets.Remove(item);
                    db.context.SaveChanges();
                }
                return true;
            }
            return false;
        }
    }
}
