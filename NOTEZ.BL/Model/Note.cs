using System;
using System.Collections.Generic;
using System.Text;

namespace NOTEZ.BL.Model
{
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastChange { get; private set; }
        public Note(string title)
        {
            Title = title;
            LastChange = DateTime.Now;
        }
    }
}
