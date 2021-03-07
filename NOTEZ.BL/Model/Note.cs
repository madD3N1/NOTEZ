using System;
using System.Collections.Generic;
using System.Text;

namespace NOTEZ.BL.Model
{
    /// <summary>
    /// Заметка.
    /// </summary>
    [Serializable]
    public class Note
    {
        #region Свойства
        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Контент.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Дата последнего изменения.
        /// </summary>
        public DateTime LastChange { get; private set; }
        #endregion

        /// <summary>
        /// Создание новой заметки.
        /// </summary>
        /// <param name="title"> Имя заметки. </param>
        public Note(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Название заметки не может быть пустым или null.", nameof(title));
            }

            Title = title;
            LastChange = DateTime.Now;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
