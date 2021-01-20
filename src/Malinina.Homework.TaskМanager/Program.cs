using System;

namespace Malinina.Homework.TaskМanager
{
    class Program
    {
        static void Main(string[] args)
        
        {
            ShowMenu();
                       
        }

        /// <summary>
        /// Displays the selection menu.
        /// </summary>
        public static void ShowMenu()
        {
            Calendar calendar = new Calendar();
           
            while (true)
            {
                Console.WriteLine("Operation selection menu:");
                Console.WriteLine("Add task - press \"1\"");
                Console.WriteLine("Edit task - press \"2\"");
                Console.WriteLine("Delete task - press \"3\"");
                Console.WriteLine("Show all task - press \"4\"");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Console.Clear();

                    switch (result)
                    {
                        case 1:
                            calendar.AddTask();
                            break;

                        case 2:
                            calendar.ShowAllTasks();
                            calendar.EditTask();
                            break;

                        case 3:
                            calendar.ShowAllTasks();
                            calendar.DeleteTask();
                            break;

                        case 4:
                            calendar.ShowAllTasks();
                            break;

                        default:
                            Console.WriteLine("Please enter correct data!");
                            break;
                    }
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
