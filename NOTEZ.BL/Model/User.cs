using System;
using System.Collections.Generic;
using System.Text;

namespace NOTEZ.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>    
        public string Name { get; }

        /// <summary>
        /// Список блокнотов.
        /// </summary>
        public List<Notebook> Notebooks { get; set; }
        #endregion

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        public User(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            Name = name;
            Notebooks = new List<Notebook>(); // TODO: Переписать, как отдельный метод в UserController.
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
