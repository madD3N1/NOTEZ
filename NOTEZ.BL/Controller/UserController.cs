using NOTEZ.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

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

            User = new User(userName);
        }

        /// <summary>
        /// Получение данных пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.Open))
            {
                if (formatter.Deserialize(fileStream) is User user)
                {
                    User = user;
                }

                // TODO: Что делать, если пользователя не прочитали?
            }
        }

        /// <summary>
        /// Сохранение данных пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, User);
            }          
        }

        /// <summary>
        /// Создание блокнота.
        /// </summary>
        /// <param name="title"> Название блокнота. </param>
        public void CreateNotebook(string title)
        {
            User.Notebooks.Add(new Notebook(title));
        }

        /// <summary>
        /// Создание заметки.
        /// </summary>
        /// <param name="titleNotebook"> Название блокнота. </param>
        /// <param name="titleNote"> Название заметки. </param>
        public void CreateNote(string titleNotebook, string titleNote)
        {
            foreach(var element in User.Notebooks)
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
