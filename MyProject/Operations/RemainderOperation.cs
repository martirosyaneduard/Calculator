namespace MyProject.Operations
{
    class RemainderOperation : IOperation
    {
        public double Operate(double x, double y)
        {
            return x % y;
        }
    }
}
