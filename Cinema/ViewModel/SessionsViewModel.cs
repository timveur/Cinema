using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    class SessionsViewModel
    {

        private static Core db = new Core();
        public bool AddSession(int idHall, int idFormat, string dateSession, string startTime, string costSession)
        {
            List<Halls> arrayHalls = db.context.Halls.ToList();
            int checkHall = arrayHalls.Where(x => x.IdHall == idHall).Count();
            if (checkHall == 0)
            {
                throw new Exception("Вы не выбрали зал.");
            }
            List<Formats> arrayFormats = db.context.Formats.ToList();
            int checkFormat = arrayFormats.Where(x => x.IdFormat == idFormat).Count();
            if (checkFormat == 0)
            {
                throw new Exception("Вы не выбрали формат.");
            }
            if (String.IsNullOrEmpty(dateSession))
            {
                throw new Exception("Вы не выбрали дату сеанса.");
            }
            if (String.IsNullOrEmpty(startTime))
            {
                throw new Exception("Вы не ввели время начала сеанса.");
            }
            if (String.IsNullOrEmpty(costSession))
            {
                throw new Exception("Вы не ввели стоимость билета.");
            }

            else
            {
                return true;
            }
        }
    }
}
