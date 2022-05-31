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
        public bool CheckAddSession(int idFormat, string dateSession, string startTime, string costSession)
        {
           
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

        /// <summary>
        /// Добавление сеанса
        /// </summary>
        /// <param name="idFilm">Идентификатор фильма</param>
        /// <param name="IdFormat">Идентификатор формата фильма</param>
        /// <param name="dateSession">Дата сеанса</param>
        /// <param name="startTime">Начало сеанса</param>
        /// <param name="endTime">Конец сеанса</param>
        /// <param name="costTicket">Стоимость билета</param>
        public void AddSession(int idFilm, int IdFormat, DateTime dateSession, TimeSpan startTime, TimeSpan endTime, Decimal costTicket)
        {
            Sessions newSession = new Sessions()
            {
                IdFilm = idFilm,
                IdFormat = IdFormat,
                DateSession = dateSession,
                StartTime = startTime,
                EndTime = endTime,
                CostTicket = costTicket
            };
            db.context.Sessions.Add(newSession);
            db.context.SaveChanges();
        }
    }
}
