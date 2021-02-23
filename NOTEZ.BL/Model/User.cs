using System;
using System.Collections.Generic;
using System.Text;

namespace NOTEZ.BL.Model
{
    public class User
    {
        public string Name { get; }
        public List<Notebook> Notebooks { get; set; }

        public User(string name)
        {
            Name = name;
            Notebooks = new List<Notebook>();
        }
    }
}
