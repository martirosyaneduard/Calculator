using Library;
using System;
namespace MyProject.Operations
{
    class MultiplyOperation : IOperation
    {
        public ConsoleKeyInfo Sign => new ConsoleKeyInfo('*', ConsoleKey.Multiply, false, false, false);

        public double Operate(double x, double y)
        {
            return x * y;
        }
    }
}
