using System;

namespace Malinina.Homework.DateInput.Handler
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
}