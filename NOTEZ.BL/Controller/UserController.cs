using NOTEZ.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NOTEZ.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Список пользователей приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Флаг нового пользователя.
        /// </summary>
        public bool IsNewUser { get; set; } = false;

        /// <summary>
        /// Флаг списка пользователей.
        /// </summary>
        public bool IsEmptyListUsers { get; set; } = true;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        public UserController()
        {
            Users = GetUsersData();

            if(Users.Count != 0)
            {
                IsEmptyListUsers = false;
            }
        }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(userName));
            }

            Users = GetUsersData();

            if (Users.Count != 0)
            {
                SetCurrentUser(userName);
            }
            else
            {
                CreateUser(userName);
            }
        }

        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <returns> Список пользователей. </returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(fileStream.Length != 0)
                {
                    if(formatter.Deserialize(fileStream) is List<User> users)
                    {
                        return users;
                    }
                    else
                    {
                        return new List<User>();
                    }
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// Поиск пользователя.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        /// <returns></returns>
        public bool UserSearch(string userName)
        {
            if(!IsEmptyListUsers)
            {
                foreach(var user in Users)
                {
                    if(user.Name == userName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        public void CreateUser(string userName)
        {      
            CurrentUser = new User(userName);         
            IsNewUser = true;
            Users.Add(CurrentUser);
            IsEmptyListUsers = false;
            Save();
        }

        /// <summary>
        /// Установка текущего пользователя.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        public void SetCurrentUser(string userName)
        {
            CurrentUser = Users.Find(u => u.Name == userName);
            IsNewUser = false;
        }

        /// <summary>
        /// Сохранение данных пользователей.
        /// </summary>
        private void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, Users);
            }          
        }

        /// <summary>
        /// Создание блокнота.
        /// </summary>
        /// <param name="title"> Название блокнота. </param>
        public void CreateNotebook(string title)
        {
            CurrentUser.Notebooks.Add(new Notebook(title));
        }

        /// <summary>
        /// Создание заметки.
        /// </summary>
        /// <param name="titleNotebook"> Название блокнота. </param>
        /// <param name="titleNote"> Название заметки. </param>
        public void CreateNote(string titleNotebook, string titleNote)
        {
            foreach(var element in CurrentUser.Notebooks)
            {
                if (element.Title == titleNotebook)
                {
                    element.Notes.Add(new Note(titleNote));
                    break;
                }
            }
        }
    }
}
