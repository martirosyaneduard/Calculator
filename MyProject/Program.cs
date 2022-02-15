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
            ICalculatorCreator creator = new CalculatorCreater();
            IMyCalculator calculator = creator.CreateCalculator();
            calculator.Start();

            Console.ReadKey();
        }
    }
}
