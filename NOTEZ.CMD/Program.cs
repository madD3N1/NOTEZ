using NOTEZ.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTEZ.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tДобро пожаловать в приложение NOTEZ!\t\t");

            Console.WriteLine("Введите имя пользователя:");
            var nameUser = Console.ReadLine();
            var testUser = new User(nameUser); // Создание нового User

            Console.WriteLine("Введите название блокнота:");
            var titleNotebook1 = Console.ReadLine();
            var notebook1 = new Notebook(titleNotebook1); // Создание нового Notebook

            testUser.Notebooks.Add(notebook1); // Добавление блокнота к списку блокнотов пользователя

            Console.WriteLine("Введите название заметки");
            var titleNote1 = Console.ReadLine();
            var note1 = new Note(titleNote1); // Создание нового Note

            notebook1.Notes.Add(note1); // Добавление заметки к списку заметок блокнота пользователя

            Console.Clear();

            Console.WriteLine($"Пользователь: {testUser}\n Блокнот: {testUser}\n Заметка: {note1}");

            Console.ReadLine();
        }
    }
}
