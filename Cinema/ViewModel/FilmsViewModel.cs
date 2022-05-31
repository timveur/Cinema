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
        public bool CheckAddFilm(string nameFilm, int ageLimit, string actors, string hoursDuration, string minuteDuration, int idCountry, int idTwoCountry, int idGenre, int IdTwoGenre)
        {
            if (String.IsNullOrEmpty(nameFilm))
            {
                throw new Exception("Вы не ввели название фильма.");
            }
            
            if (idCountry == 0)
            {
                throw new Exception("Вы не выбрали страну.");
            }
            if (idCountry == idTwoCountry)
            {
                throw new Exception("Вы выбрали две одинаковых страны.");
            }
            if (idGenre == 0)
            {
                throw new Exception("Вы не выбрали жанр.");
            }
            if (idGenre == IdTwoGenre)
            {
                throw new Exception("Вы выбрали два одинаковых жанра.");
            }
            if (ageLimit == 0)
            {
                throw new Exception("Вы не выбрали возрастное ограничение.");
            }
            if (String.IsNullOrEmpty(hoursDuration) || String.IsNullOrEmpty(minuteDuration))
            {
                throw new Exception("Вы не ввели длительность фильма.");
            }
            int check = 0;
            foreach (char item in (hoursDuration + minuteDuration))
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
            if (String.IsNullOrEmpty(actors))
            {
                throw new Exception("Вы не ввели актеров фильма.");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Добавление фильма
        /// </summary>
        /// <param name="nameFilm">Название фильма</param>
        /// <param name="description">Описание</param>
        /// <param name="idAgeLimit">Идентификатор возрастного ограничения</param>
        /// <param name="selectedDuration">Длительность фильма</param>
        /// <param name="actors">Актеры</param>
        /// <param name="filmsCompany">Кинокомпания</param>
        /// <param name="filmsDirector">Продюссер(-ы)</param>
        /// <param name="photoPath">Название файла с фото</param>
        /// <param name="idCountry">Идентификатор первой страны</param>
        /// <param name="idTwoCountry">Идентификатор второй страны</param>
        /// <param name="idGenre">Идентификатор первого жанра</param>
        /// <param name="idTwoGenre">Идентификатор второго жанра</param>
        public void AddFilm(string nameFilm, string description, int idAgeLimit, TimeSpan selectedDuration, string actors, string filmsCompany, string filmsDirector, string photoPath, int idCountry, int idTwoCountry, int idGenre, int idTwoGenre)
        {
            Films newFilm = new Films()
            {
                NameFilm = nameFilm,
                IdAgeLimit = idAgeLimit,
                Duration = selectedDuration,
                Actors = actors,
                PhotoPath = (photoPath != "") ? photoPath : "_nonephoto.jpg"
            };
            if (!String.IsNullOrEmpty(description))
            {
                newFilm.DescriptionFilm = description;
            }
            if (!String.IsNullOrEmpty(filmsCompany))
            {
                newFilm.FilmsCompany = filmsCompany;
            }
            if (!String.IsNullOrEmpty(filmsDirector))
            {
                newFilm.FilmsDirectors = filmsDirector;
            }
            db.context.Films.Add(newFilm);
            int idFilm = newFilm.IdFilm;
            FilmsCountries newFilmsCountries = new FilmsCountries()
            {
                IdCountry = idCountry,
                IdFilm = idFilm
            };
            db.context.FilmsCountries.Add(newFilmsCountries);
            if (idTwoCountry != 0)
            {
                FilmsCountries newTwoFilmsCountries = new FilmsCountries()
                {
                    IdCountry = idTwoCountry,
                    IdFilm = idFilm
                };
                db.context.FilmsCountries.Add(newTwoFilmsCountries);
            }
            FilmsGenres newFilmsGenres = new FilmsGenres()
            {
                IdGenre = idGenre,
                IdFilm = idFilm
            };
            db.context.FilmsGenres.Add(newFilmsGenres);
            if (idTwoGenre != 0)
            {
                FilmsGenres newTwoFilmsGenres = new FilmsGenres()
                {
                    IdGenre = idTwoGenre,
                    IdFilm = idFilm
                };
                db.context.FilmsGenres.Add(newTwoFilmsGenres);
            }
            db.context.SaveChanges();
        }

        /// <summary>
        /// Редактирование фильма
        /// </summary>
        /// <param name="idFilm">Идентификатор фильма</param>
        /// <param name="nameFilm">Название фильма</param>
        /// <param name="description">Описание</param>
        /// <param name="idAgeLimit">Идентификатор возрастного ограничения</param>
        /// <param name="selectedDuration">Длительность фильма</param>
        /// <param name="actors">Актеры</param>
        /// <param name="filmsCompany">Кинокомпания</param>
        /// <param name="filmsDirector">Продюссер(-ы)</param>
        /// <param name="photoPath">Название файла с фото</param>
        /// <param name="idCountry">Идентификатор первой страны</param>
        /// <param name="idTwoCountry">Идентификатор второй страны</param>
        /// <param name="idGenre">Идентификатор первого жанра</param>
        /// <param name="idTwoGenre">Идентификатор второго жанра</param>
        public void EditFilm(int idFilm, string nameFilm, string description, int idAgeLimit, TimeSpan selectedDuration, string actors, string filmsCompany, string filmsDirector, string photoPath, int idCountry, int idTwoCountry, int idGenre, int idTwoGenre)
        {
            var uFilms = db.context.Films.Where(x => x.IdFilm == idFilm).FirstOrDefault();
            uFilms.NameFilm = nameFilm;
            uFilms.IdAgeLimit = idAgeLimit;
            uFilms.Duration = selectedDuration;
            uFilms.Actors = actors;
            uFilms.PhotoPath = (photoPath != "") ? photoPath : "_nonephoto.jpg";
            var uCountries = uFilms.FilmsCountries.FirstOrDefault();
            var uGenres = uFilms.FilmsGenres.FirstOrDefault();
            List<FilmsGenres> arrayFilmsGenres = db.context.FilmsGenres.Where(x=>x.IdFilm==idFilm).ToList();
            List<FilmsCountries> arrayFilmsCountries = db.context.FilmsCountries.Where(x=>x.IdFilm==idFilm).ToList();
            List<int> idFilmCountries = new List<int>();
            if (arrayFilmsCountries!=null)
            {
                foreach (var item in arrayFilmsCountries)
                {
                    idFilmCountries.Add(item.IdFilmCountry);
                }
                
            }
            int idCountrySelect;
            if (idFilmCountries.Count == 0)
            {
                FilmsCountries newFilmsCountries = new FilmsCountries()
                {
                    IdCountry = idCountry,
                    IdFilm = idFilm
                };
                db.context.FilmsCountries.Add(newFilmsCountries);

            }
            if (idTwoCountry == 0 && idFilmCountries.Count == 1)
            {
                uCountries.IdCountry = idCountry;
                uCountries.IdFilm = idFilm;
            }
            if (idTwoCountry!=0 && idFilmCountries.Count == 1)
            {
                FilmsCountries newFilmsCountries = new FilmsCountries()
                {
                    IdCountry = idTwoCountry,
                    IdFilm = idFilm
                };
                db.context.FilmsCountries.Add(newFilmsCountries);
            }
            if (idFilmCountries.Count == 2)
            {
                idCountrySelect = idFilmCountries[1];
                var uCountriesTwo = db.context.FilmsCountries.Where(x => x.IdFilmCountry == idCountrySelect).FirstOrDefault();
                if (idCountry != uCountries.IdCountry && idTwoCountry != uCountriesTwo.IdCountry) 
                {
                    uCountries.IdCountry = idCountry;
                    uCountries.IdFilm = idFilm;
                    uCountriesTwo.IdCountry = idTwoCountry;
                    uCountriesTwo.IdFilm = idFilm;
                }
                if (idTwoCountry == uCountriesTwo.IdCountry && idCountry != uCountries.IdCountry)
                {
                    uCountries.IdCountry = idCountry;
                    uCountries.IdFilm = idFilm;
                }
                if (idCountry == uCountries.IdCountry && idTwoCountry != uCountriesTwo.IdCountry)
                {
                    uCountriesTwo.IdCountry = idTwoCountry;
                    uCountriesTwo.IdFilm = idFilm;
                }
                if (idTwoCountry == 0 && uCountriesTwo.IdFilmCountry != 0)
                {
                    db.context.FilmsCountries.Remove(uCountriesTwo);
                }
            }

            List<int> idFilmGenres = new List<int>();
            if (arrayFilmsGenres!=null)
            {
                foreach (var item in arrayFilmsGenres)
                {
                    idFilmGenres.Add(item.IdFilmGenre);
                }
            }
            int idGenreSelect;
            Console.WriteLine(idFilmGenres.Count);
            if (idFilmGenres.Count == 0)
            {
                FilmsGenres newFilmsGenres = new FilmsGenres()
                {
                    IdGenre = idGenre,
                    IdFilm = idFilm
                };
                db.context.FilmsGenres.Add(newFilmsGenres);

            }
            if (idTwoGenre == 0 && idFilmGenres.Count == 1)
            {
                uGenres.IdGenre = idGenre;
                uGenres.IdFilm = idFilm;
            }            
            if (idTwoGenre != 0 && idFilmGenres.Count == 1)
            {
                FilmsGenres newFilmsGenres = new FilmsGenres()
                {
                    IdGenre = idTwoGenre,
                    IdFilm = idFilm
                };
                db.context.FilmsGenres.Add(newFilmsGenres);
            }
            if (idFilmGenres.Count == 2)
            {
                idGenreSelect = idFilmGenres[1];
                var uGenresTwo = db.context.FilmsGenres.Where(x => x.IdFilmGenre == idGenreSelect).FirstOrDefault();
                if (idGenre != uGenres.IdGenre && idTwoGenre != uGenresTwo.IdGenre)
                {
                    uGenres.IdGenre = idGenre;
                    uGenres.IdFilm = idFilm;
                    uGenresTwo.IdGenre = idTwoGenre;
                    uGenresTwo.IdFilm = idFilm;

                }
                if (idTwoGenre == uGenresTwo.IdGenre && idGenre!= uGenres.IdGenre) 
                {
                    uGenres.IdGenre = idGenre;
                    uGenres.IdFilm = idFilm;
                }
                if (idGenre == uGenres.IdGenre && idTwoGenre != uGenresTwo.IdGenre)
                {
                    uGenresTwo.IdGenre = idTwoGenre;
                    uGenresTwo.IdFilm = idFilm;
                }
                if (idTwoGenre == 0 && uGenresTwo.IdFilmGenre != 0)
                {
                    db.context.FilmsGenres.Remove(uGenresTwo);
                }
                
            }
            if (!String.IsNullOrEmpty(description))
            {
                uFilms.DescriptionFilm = description;
            }
            if (!String.IsNullOrEmpty(filmsCompany))
            {
                uFilms.FilmsCompany = filmsCompany;
            }
            if (!String.IsNullOrEmpty(filmsDirector))
            {
                uFilms.FilmsDirectors = filmsDirector;
            }
            db.context.SaveChanges();
        }
    }
}
