using System;

namespace MyProject.Operations
{
    class DivideOperation : IOperation
    {
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
