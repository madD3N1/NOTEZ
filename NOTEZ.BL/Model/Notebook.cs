using System;
using System.Collections.Generic;
using System.Text;

namespace NOTEZ.BL.Model
{
    public class Notebook
    {
        public string Title { get; set; }
        public List<Note> Notes { get; set; }
        public DateTime LastChange { get; private set; }

        public Notebook(string title)
        {
            Title = title;
            Notes = new List<Note>();
            LastChange = DateTime.Now;
        }
    }
}
