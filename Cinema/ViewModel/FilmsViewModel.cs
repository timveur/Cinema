using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    class FilmsViewModel
    {
        private static Core db = new Core();
        public bool AddFilm(string nameFilm, int ageLimit, string actors)
        {
            if (String.IsNullOrEmpty(nameFilm))
            {
                throw new Exception("Вы не ввели название фильма.");
            }
            List<AgeLimits> arrayAgeLimit = db.context.AgeLimits.ToList();
            int checkAgeLimit = arrayAgeLimit.Where(x => x.IdAgeLimit == ageLimit).Count();
            if (checkAgeLimit == 0)
            {
                throw new Exception("Вы не выбрали возрастное ограничение.");
            }
            if (String.IsNullOrEmpty(actors))
            {
                throw new Exception("Вы не ввели актеров фильма.");
            }
            
            else
            {
                return true;
            }
        }

        


        public bool AddFilmCheckDuration(string hoursDuration, string minuteDuration)
        {
            if (String.IsNullOrEmpty(hoursDuration) || String.IsNullOrEmpty(minuteDuration))
            {
                throw new Exception("Вы не ввели длительность фильма.");
            }
            int check = 0;
            foreach (char item in (hoursDuration+minuteDuration))
            {
                if (!Char.IsDigit(item))
                {
                    check += 1;
                }
            }

            if (check != 0 || Convert.ToInt32(hoursDuration) > 12 || Convert.ToInt32(minuteDuration) > 59)
            {
                throw new Exception("Некорректная длительность фильма.");
            }
            else
            {
                return true;
            }
        }
    }
}
