using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ViewModel
{
    class RegViewModel
    {
        private static Core db = new Core();
        public bool CheckRegUser(string lastName, string firstName, string patronymic, string login, string email, string password, string repeatPassword)
        {

            List<Users> arrayUsers = db.context.Users.ToList();
            
            
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


    }
}
