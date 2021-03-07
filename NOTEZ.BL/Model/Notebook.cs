using System;
using System.Collections.Generic;
using System.Text;

namespace NOTEZ.BL.Model
{
    /// <summary>
    /// Блокнот.
    /// </summary>
    [Serializable]
    public class Notebook
    {
        #region Свойства
        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Список заметок.
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Дата последнего изменения.
        /// </summary>
        public DateTime LastChange { get; private set; }
        #endregion

        /// <summary>
        /// Создание нового блокнота.
        /// </summary>
        /// <param name="title"> Название блокнота. </param>
        public Notebook(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Название блокнота не может быть пустым или null.", nameof(title));
            }

            Title = title;
            Notes = new List<Note>();
            LastChange = DateTime.Now;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
