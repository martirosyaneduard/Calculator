using System;
using Library;

namespace MyProject.Operations
{
    class DivideOperation : IOperation
    {
        public ConsoleKeyInfo Sign => new ConsoleKeyInfo('/',ConsoleKey.Divide,false,false,false);

        public double Operate(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }
    }
}
