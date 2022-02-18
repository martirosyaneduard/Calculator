using Library;
using System;
namespace MyProject.Operations
{
    class SubtractOperation : IOperation
    {
        public ConsoleKeyInfo Sign => new ConsoleKeyInfo('-', ConsoleKey.Subtract, false, false, false);

        public double Operate(double x, double y)
        {
            return x - y;
        }
    }
}
