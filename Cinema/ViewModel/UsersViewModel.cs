using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    public class UsersViewModel
    {
        private static Core db = new Core();

        /// <summary>
        /// Поиск пользователя в базе данных
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
            if (checkClient == 0)
            {
                throw new Exception("Пользователь не найден.");
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Проверка корректности ввода данных при регистрации
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="login">Логин</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="repeatPassword">Повтор пароля</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool CheckRegUser(string lastName, string firstName, string login, string email, string password, string repeatPassword)
        {            
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(login) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                throw new Exception("Вы ввели не все данные.");
            }
            if (repeatPassword != password)
            {
                throw new Exception("Пароли не совпадают.");
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="login">Логин</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="phone">Номер телефона</param>
        public void AddUser(string lastName, string firstName, string patronymic, string login, string email, string password, string phone)
        {
            Users newUser = new Users()
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Email = email,
                Password = password,
                IdRole = 3
            };
            if (!String.IsNullOrEmpty(patronymic))
            {
                newUser.Patronymic = patronymic;
            }
            if (!String.IsNullOrEmpty(phone))
            {
                newUser.Phone = phone;
            }
            db.context.Users.Add(newUser);
            db.context.SaveChanges();
        }


        /////////////////////// For tests ///////////////////////


        /// <summary>
        /// Добавление пользователя (тестирование)
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="login">Логин</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="phone">Номер телефона</param>
        public bool CheckAddUser(string lastName, string firstName, string patronymic, string login, string email, string password, string phone)
        {
            Users newUser = new Users()
            {
                FirstName = firstName,
                LastName = lastName,
                Login = login,
                Email = email,
                Password = password,
                IdRole = 3
            };
            if (!String.IsNullOrEmpty(patronymic))
            {
                newUser.Patronymic = patronymic;
            }
            if (!String.IsNullOrEmpty(phone))
            {
                newUser.Phone = phone;
            }
            db.context.Users.Add(newUser);
            db.context.SaveChanges();

            int countRecords = db.context.Users.Where(x => x.LastName == lastName && x.FirstName == firstName && x.Login == login && x.Email == email && x.Password == password).Count();
            if (countRecords == 1)
            {
                db.context.Users.Remove(newUser);
                db.context.SaveChanges();
                return true;
            }
            return false;

            

        }


    }
}
