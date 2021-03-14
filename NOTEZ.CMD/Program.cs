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
            var userController = new UserController();

            while(MainMenu(ref userController)) { }

            while(UserMenu(ref userController)) { }

            Console.ReadLine();
        }

        /// <summary>
        /// Создание Главного меню.
        /// </summary>
        /// <param name="userController"> Контроллер пользователя. </param>
        /// <returns> Флаг остановки. </returns>
        static bool MainMenu(ref UserController userController)
        {
            Console.WriteLine("\t\tДобро пожаловать в приложение NOTEZ!\t\t\n");
            Console.WriteLine("Для выбора пунктов Меню используйте соответствующие числа.\n");
            Console.WriteLine("1 - Войти как зарегистрированный пользователь.");
            Console.WriteLine("2 - Зарегистрироваться.");
            Console.WriteLine("0 - Выйти из приложения");

            string choice;
            bool flagChoice = true;
            bool flagStop = false;

            while (flagChoice)
            {
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        userController = UserAuthorization(ref flagStop);
                        flagChoice = false;
                        break;
                    case "2":
                        Console.Clear();
                        userController = UserRegistration(ref flagStop);
                        flagChoice = false;
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неккоректные данные.");
                        break;
                }
            }

            if(flagStop)
            {
                return false;
            }

            return true;    
        }

        /// <summary>
        /// Создания Меню пользователя.
        /// </summary>
        /// <param name="userController"> Контроллер пользователя. </param>
        /// <returns> Флаг остановки. </returns>
        static bool UserMenu(ref UserController user)
        {
            Console.WriteLine($"\t\tВы вошли как {user.CurrentUser}\t\t");
            Console.WriteLine("Для выбора пунктов Меню используйте соответствующие числа.\n");
            Console.WriteLine("1 - Просмотреть все Блокноты.");
            Console.WriteLine("2 - Создать новый Блокнот.");
            Console.WriteLine("0 - Выйти из приложения.");

            string choice;
            bool flagChoice = true;
            bool flagStop = false;

            while (flagChoice)
            {
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        NotebookViewMenu(ref user);
                        flagChoice = false;
                        break;
                    case "2":
                        Console.Clear();
                        NotebookCreationMenu(ref user);
                        flagChoice = false;
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неккоректные данные.");
                        break;
                }
            }

            if (flagStop)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="isStop"> Флаг остановки. </param>
        /// <returns> Контроллер пользователя. </returns>
        static UserController UserRegistration(ref bool flagStop)
        {
            var userController = new UserController();

            Console.WriteLine("\tЧтобы вернуться в меню, введите 0.");
            Console.WriteLine("Введите имя пользователя:");

            string userName;

            while (true)
            {
                userName = Console.ReadLine();

                if(userName == "0")
                {
                    Console.Clear();
                    return userController;
                }
                else if(userController.UserSearch(userName))
                {
                    Console.WriteLine("Такой пользователь уже существует. Введите другое имя пользователя:");
                }
                else
                {
                    userController.CreateUser(userName);
                    Console.Clear();
                    flagStop = true;
                    return userController;
                }
            }
        }

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="isStop"> Флаг остановки. </param>
        /// <returns> Контроллер пользователя. </returns>
        static UserController UserAuthorization(ref bool flagStop)
        {
            var userController = new UserController();

            Console.WriteLine("\tЧтобы вернуться в меню, введите 0.");
            Console.WriteLine("Введите имя пользователя:");

            string userName;

            while (true)
            {
                userName = Console.ReadLine();

                if (userName == "0")
                {
                    Console.Clear();
                    return userController;
                }
                else if (userController.UserSearch(userName))
                {
                    userController.SetCurrentUser(userName);
                    Console.Clear();
                    flagStop = true;
                    return userController;
                }
                else
                {
                    Console.WriteLine("Пользователь не найден. Введите другое имя пользователя:");
                }
            }         
        }

        /// <summary>
        /// Меню просмотра и выбора Блокнотов.
        /// </summary>
        /// <param name="flagStop"> Флаг остановки. </param>
        /// <param name="user"> Контроллер пользователя. </param>
        static void NotebookViewMenu(ref UserController user)
        {
            Console.WriteLine("Для выбора Блокнота введите его название.");
            Console.WriteLine("Для возврата в предыдущее меню введите 0.");

            foreach (var notebook in user.CurrentUser.Notebooks)
            {
                Console.WriteLine($"Блокнот: {notebook}\n");
                Console.WriteLine($"\tЗаметки:");
                foreach (var note in notebook.Notes)
                {
                    Console.WriteLine($"\t\t{note}\n");
                }
            }

            string choice;
            bool flagStop = false;

            while(true)
            {
                choice = Console.ReadLine();

                if(choice == "0")
                {
                    Console.Clear();
                    break;
                }

                foreach(var notebook in user.CurrentUser.Notebooks)
                {
                    if(choice == notebook.Title)
                    {
                        Console.Clear();
                        flagStop = true;
                        break;
                    }
                }

                if(flagStop)
                {
                    break;
                }

                Console.WriteLine("Неверное название Блокнота. Повторите попытку ввода:");
            }
        }

        /// <summary>
        /// Меню создания нового Блокнота.
        /// </summary>
        /// <param name="flagStop"> Флаг остановки. </param>
        /// <param name="user"> Контроллер пользователя. </param>
        static void NotebookCreationMenu(ref UserController user)
        {
            Console.WriteLine("Для возврата в предыдущее меню введите 0.");
            Console.WriteLine("Введите название нового Блокнота.");

            string notebookTitle;
            bool flagStop = false;

            while(true)
            {
                notebookTitle = Console.ReadLine();

                if (notebookTitle == "0")
                {
                    Console.Clear();
                    break;
                }

                foreach (var notebook in user.CurrentUser.Notebooks)
                {
                    if(notebookTitle == notebook.Title)
                    {
                        flagStop = true;
                        break;
                    }
                }

                if (!flagStop)
                {
                    user.CreateNotebook(notebookTitle);
                    break;
                }
                
                Console.WriteLine("Блокнот с таким именем уже существует. Введите другое имя Блокнота:");
            }         
        }

        // TODO: Написать метод отображения конкретного Блокнота и создания новой заметки
        // TODO: Написать метод отображение/редактирования заметки
    }
}
