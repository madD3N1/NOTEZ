using NOTEZ.BL.Controller;
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
            var testUser = new UserController(nameUser);

            Console.WriteLine("Введите название блокнота:");
            var titleNotebook1 = Console.ReadLine();
            testUser.CreateNotebook(titleNotebook1);

            Console.WriteLine("Введите название заметки:");
            var titleNote1 = Console.ReadLine();
            testUser.CreateNote(titleNotebook1, titleNote1);

            testUser.Save();

            Console.Clear();

            Console.WriteLine($"Пользователь: {testUser.User}\n");
            foreach (var notebook in testUser.User.Notebooks)
            {
                Console.WriteLine($"\tБлокнот: {notebook}\n");
                foreach (var note in notebook.Notes)
                {
                    Console.WriteLine($"\t\tЗаметка: {note}\n");
                }
            }

            Console.ReadLine();
        }
    }
}
