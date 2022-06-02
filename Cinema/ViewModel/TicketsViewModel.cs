using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    class TicketsViewModel
    {
        private static Core db = new Core();

        public void AddTicket(int idSession, List<int> arrayIdSeats)
        {
            foreach (var item in arrayIdSeats)
            {
                Tickets newTicket = new Tickets()
                {
                    IdSession = idSession,
                    IdSeat = item
                };
                db.context.Tickets.Add(newTicket);
            }
            db.context.SaveChanges();
        }
    }
}
