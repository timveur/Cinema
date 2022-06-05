using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    public class SessionsViewModel
    {

        private static Core db = new Core();
        public bool CheckAddSession(int idFormat, string dateSession, string startTime, string costSession)
        {
            if (idFormat == 0)
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
            int check = 0;
            foreach (var item in costSession)
            {
                if (!Char.IsDigit(item))
                {
                    check += 1;
                }
            }
            if (String.IsNullOrEmpty(costSession))
            {
                throw new Exception("Вы не ввели стоимость билета.");
            }
            if (check > 0)
            {
                throw new Exception("Некорректная стоимость билета.");
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


        //////////////////////////////////////// For tests //////////////////////////////////////////////

        /// <summary>
        /// Добавление сеанса (тестирование)
        /// </summary>
        /// <param name="idFilm">Идентификатор фильма</param>
        /// <param name="IdFormat">Идентификатор формата фильма</param>
        /// <param name="dateSession">Дата сеанса</param>
        /// <param name="startTime">Начало сеанса</param>
        /// <param name="endTime">Конец сеанса</param>
        /// <param name="costTicket">Стоимость билета</param>
        public bool AddSessionTest(int idFilm, int IdFormat, DateTime dateSession, TimeSpan startTime, TimeSpan endTime, Decimal costTicket)
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
            int countRecords = db.context.Sessions.Where(x => x.IdFilm == idFilm && x.IdFormat == IdFormat && x.DateSession == dateSession && x.StartTime == startTime && x.CostTicket == costTicket).Count();
            if (countRecords == 1)
            {
                db.context.Sessions.Remove(newSession);
                db.context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
