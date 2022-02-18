using Library;
using System;
namespace MyProject.Operations
{
    class SumOperation : IOperation
    {
        public ConsoleKeyInfo Sign => new ConsoleKeyInfo('+', ConsoleKey.Add, false, false, false);

        public double Operate(double x, double y)
        {
            return x + y;
        }
    }
}
