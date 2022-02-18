using System;
namespace Library
{
    public interface IOperation
    {
        ConsoleKeyInfo Sign { get;}
        double Operate(double x, double y);
    }
}
