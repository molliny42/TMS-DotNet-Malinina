using System;

namespace Homework1
{
  
    class Program
    {
        static void Main(string[] args)
        {
            int number = 2;
            Console.WriteLine(number);
            SetNumber(number);
            Console.WriteLine(number);
        }

        static void SetNumber(int a)
        {
            a = 5;
        }
    }
}
