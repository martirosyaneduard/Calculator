using MyProject.Container;
using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Go();
        }
        public static void Go()
        {
            MyCalculator calculator = new MyCalculator();
            calculator.Start();
            Console.ReadKey();
        }
    }
}
