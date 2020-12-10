using System;

namespace CalculationDifferenceDates
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Enter date: ");
                string inputValue = Console.ReadLine();

                if (DateTime.TryParse(inputValue, out DateTime date))
                {
                    Console.WriteLine($"Day is - {date.DayOfWeek}");
                }
                else
                {
                    Console.WriteLine("Incorrect date!");
                }
            }
        }
    }
}


/*using System;

namespace Malinina.Homework.DateInputHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                
                if (!TryGetDate(out DateTime date))
                {
                    Console.WriteLine("Uncorrect date");
                }
                else
                {
                    Console.WriteLine($"Day is - {date.DayOfWeek}");
                }
            }         
        }

        static bool TryGetDate(out DateTime date)
        {
            Console.WriteLine("Enter date: ");

            string input = Console.ReadLine();

            return DateTime.TryParse(input, out date);
        
        }
    }
}*/