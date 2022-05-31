using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    class CheckClass
    {
        private static Core db = new Core();
        /// <summary>
        /// Проверка корректности заполнения полей при регистрации
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool CheckAuth(string login, string password)
        {
            if (String.IsNullOrEmpty(login))
            {
                throw new Exception("Вы не ввели логин.");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("Вы не ввели пароль.");
            }
            int checkClient = db.context.Users.Where(x => x.Login == login && x.Password == password).Count();
            if (checkClient==0)
            {
                throw new Exception("Пользователь не найден.");
            }
            else
            {
                return true;
            }
        }
    }
}
