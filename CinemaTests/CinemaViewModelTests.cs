using CinemaTests.ModelTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Cinema.ViewModel;
using System.Collections.Generic;
using System.Linq;
using Cinema.Model;

namespace CinemaTests
{
    [TestClass]
    public class CinemaViewModelTests
    {
        CoreTests dbTest = new CoreTests();
        Core db = new Core();
        /// <summary>
        /// Тест на нахождение в базе существующего пользователя
        /// </summary>
        [TestMethod]
        public void CheckAuth_Admin_admin123_TrueReturned()
        {
            //Arrange
            string login = "Admin";
            string password = "admin123";
            bool expected = true;
            //Act
            UsersViewModel newObject = new UsersViewModel();
            bool actual = newObject.CheckAuth(login, password);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на вызов исключения при НЕнахождении НЕсуществующего пользователя
        /// </summary>
        [TestMethod]
        public void CheckAuth_testfalse_test_ExceptionReturned()
        {
            //Arrange
            string login = "testfalse";
            string password = "test";
            //Act
            UsersViewModel newObject = new UsersViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.CheckAuth(login, password));
        }


        /// <summary>
        /// Тест на корректность ввода обязательынх данных при регистрации
        /// </summary>
        [TestMethod]
        public void CheckRegUser_Familia_Name_Login_emailmailru_pass_pass_TrueReturned()
        {
            //Arrange
            string lastName = "Familia";
            string firstName = "Name";
            string login = "Login";
            string email = "email@mail.ru";
            string password = "pass";
            string passwordRepeat = "pass";
            bool expected = true;
            //Act
            UsersViewModel newObject = new UsersViewModel();
            bool actual = newObject.CheckRegUser(lastName,firstName,login,email,password,passwordRepeat);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Тест на вызов исключения при НЕзаполнении обязательынх данных при регистрации
        /// </summary>
        [TestMethod]
        public void CheckRegUser_Familia_Login_emailmailru_pass_pass_ExceptionReturned()
        {
            //Arrange
            string lastName = "Familia";
            string firstName = "";
            string login = "Login";
            string email = "email@mail.ru";
            string password = "pass";
            string passwordRepeat = "pass";
            //Act
            UsersViewModel newObject = new UsersViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.CheckRegUser(lastName, firstName, login, email, password, passwordRepeat));
        }

        /// <summary>
        /// Тест на добавление нового пользователя
        /// </summary>
        [TestMethod]
        public void CheckAddUser_Familia_Name_null_Login_emailmailru_pass_89829812674_TrueReturned()
        {
            //Arrange
            string lastName = "Familia";
            string firstName = "Name";
            string patronymic = "";
            string login = "Login";
            string email = "email@mail.ru";
            string password = "pass";
            string phone = "89829812674";
            bool expected = true;
            //Act
            UsersViewModel newObject = new UsersViewModel();
            bool actual = newObject.CheckAddUser(lastName, firstName, patronymic, login, email, password, phone);
            //Assert
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        /// Тест на корректность введенных данных при добавлении фильма
        /// </summary>
        [TestMethod]
        public void CheckAddFilm_NameFilm_2_Actoractor_2_15_99_0_4_0_TrueReturned()
        {
            //Arrange
            string nameFilm = "NameFilm";
            int idAgeLimit = 2;
            string actors = "Actor, actor";
            string hoursDuration = "2";
            string minutesDuration = "15";
            int idCountry = 99;
            int idTwoCountry = 0;
            int idGenre = 4;
            int idTwoGenre = 0;
            bool expected = true;
            //Act
            FilmsViewModel newObject = new FilmsViewModel();
            bool actual = newObject.CheckAddFilm(nameFilm, idAgeLimit, actors, hoursDuration, minutesDuration, idCountry, idTwoCountry, idGenre, idTwoGenre);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Тест на вызов исключения при НЕправильно введенных данных при добавлении фильма
        /// </summary>
        [TestMethod]
        public void CheckAddFilm_NameFilm_2_null_два_15_99_0_4_0_ExceptionReturned()
        {
            //Arrange
            string nameFilm = "NameFilm";
            int idAgeLimit = 2;
            string actors = "";
            string hoursDuration = "два";
            string minutesDuration = "15";
            int idCountry = 99;
            int idTwoCountry = 0;
            int idGenre = 4;
            int idTwoGenre = 0;
            //Act
            FilmsViewModel newObject = new FilmsViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.CheckAddFilm(nameFilm, idAgeLimit, actors, hoursDuration, minutesDuration, idCountry, idTwoCountry, idGenre, idTwoGenre));
        }


        /// <summary>
        /// Тест на добавление фильма
        /// </summary>
        [TestMethod]
        public void AddFilmTest_NameFilm_null_2_2150_Actoractor_null_Director1_null_99_4_TrueReturned()
        {
            //Arrange
            string nameFilm = "NameFilm";
            string description = "";
            int idAgeLimit = 2;
            TimeSpan selectedDuration = new TimeSpan(2, 15, 0);
            string actors = "Actor, actor";
            string filmsCompany = "";
            string filmsDirector = "Director 1";
            string photoPath = "";
            int idCountry = 99;
            int idGenre = 4;
            bool expected = true;
            //Act
            FilmsViewModel newObject = new FilmsViewModel();
            bool actual = newObject.AddFilmTest(nameFilm, description, idAgeLimit, selectedDuration, actors, filmsCompany, filmsDirector, photoPath, idCountry, idGenre);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на редактирование фильма
        /// </summary>
        [TestMethod]
        public void EditFilmTest_7_NameFilmTest_null_2_2150_Actoractor_null_Director1_null_99_4_TrueReturned()
        {
            //Arrange
            int idFilm = 7;
            string nameFilm = "NameFilmTest";
            string description = "";
            int idAgeLimit = 2;
            TimeSpan selectedDuration = new TimeSpan(2, 15, 0);
            string actors = "Actor, actor";
            string filmsCompany = "";
            string filmsDirector = "Director 1";
            string photoPath = "";
            int idCountry = 99;
            int idGenre = 4;
            bool expected = true;
            //Act
            FilmsViewModel newObject = new FilmsViewModel();
            bool actual = newObject.EditFilmTest(idFilm, nameFilm, description, idAgeLimit, selectedDuration, actors, filmsCompany, filmsDirector, photoPath, idCountry, idGenre);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на удаление фильма
        /// </summary>
        [TestMethod]
        public void DeleteFilmTest_1009_TrueReturned()
        {
            //Arrange
            int idFilm = 1009;
            bool expected = true;
            //Act
            FilmsViewModel newObject = new FilmsViewModel();
            bool actual = newObject.DeleteFilmTest(idFilm);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на проверку корректности введенных данных при добавлении сеанса
        /// </summary>
        [TestMethod]
        public void CheckAddSession_2_1062022_14200_200_TrueReturned()
        {
            //Arrange
            int idFormat = 2;
            DateTime newDate = new DateTime(2022, 6, 10);
            string dateSession = Convert.ToString(newDate);
            TimeSpan newTime = new TimeSpan(14, 20, 0);
            string startTime = Convert.ToString(newTime);
            string costSession = "200";
            bool expected = true;
            //Act
            SessionsViewModel newObject = new SessionsViewModel();
            bool actual = newObject.CheckAddSession(idFormat, dateSession, startTime, costSession);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на вызов исключения при введении НЕкорректных данных при добавлении сеанса
        /// </summary>
        [TestMethod]
        public void CheckAddSession_2_1062022_14200_двести_ExceptionReturned()
        {
            //Arrange
            int idFormat = 2;
            DateTime newDate = new DateTime(2022, 6, 10);
            string dateSession = Convert.ToString(newDate);
            TimeSpan newTime = new TimeSpan(14, 20, 0);
            string startTime = Convert.ToString(newTime);
            string costSession = "двести";
            //Act
            SessionsViewModel newObject = new SessionsViewModel();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.CheckAddSession(idFormat, dateSession, startTime, costSession));
        }


        /// <summary>
        /// Тест на добавление сеанса
        /// </summary>
        [TestMethod]
        public void AddSessionTest_5_2_1062022_14200_1360_200_TrueReturned()
        {
            //Arrange
            int idFilm = 5;
            int idFormat = 2;
            DateTime dateSession = new DateTime(2022, 6, 10);
            TimeSpan startTime = new TimeSpan(14, 20, 0);
            TimeSpan duration = new TimeSpan(1, 36, 0);
            TimeSpan endTime = startTime + duration;
            Decimal costSession = 200;
            bool expected = true;
            //Act
            SessionsViewModel newObject = new SessionsViewModel();
            bool actual = newObject.AddSessionTest(idFilm, idFormat, dateSession, startTime, endTime, costSession);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на "покупку" одного билета (добавление в БД)
        /// </summary>
        [TestMethod]
        public void AddTicketTest_15_6_TrueReturned()
        {
            //Arrange
            int idSession = 15;
            List<int> arrayIdSeats = new List<int>() { 6 };
            bool expected = true;
            //Act
            TicketsViewModel newObject = new TicketsViewModel();
            bool actual = newObject.AddTicketTest(idSession, arrayIdSeats);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на "покупку" нескольких билетов (добавление в БД)
        /// </summary>
        [TestMethod]
        public void AddTicketTest_15_20_21_TrueReturned()
        {
            //Arrange
            int idSession = 15;
            List<int> arrayIdSeats = new List<int>() { 20, 21 };
            bool expected = true;
            //Act
            TicketsViewModel newObject = new TicketsViewModel();
            bool actual = newObject.AddTicketTest(idSession, arrayIdSeats);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
