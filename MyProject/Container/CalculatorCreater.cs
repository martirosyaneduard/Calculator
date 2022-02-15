using MyProject.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyProject.Container
{
    class CalculatorCreater : ICalculatorCreator
    {
        private List<IOperation> _defaultOperations = new List<IOperation>();
        public IMyCalculator CreateCalculator()
        {
            IEnumerable<IOperation> operations = GetOperations();
            _defaultOperations.Add(new SumOperation());
            _defaultOperations.Add(new SubtractOperation());
            _defaultOperations.Add(new DivideOperation());
            _defaultOperations.Add(new MultiplyOperation());
            _defaultOperations.Add(new RemainderOperation());
            _defaultOperations.AddRange(operations);
            return new MyCalculator(_defaultOperations);
        }

        public IEnumerable<IOperation> GetOperations()
        {
            List<IOperation> operations = new List<IOperation>();
            string location = Assembly.GetExecutingAssembly().Location;
            int lastIndex = location.LastIndexOf('\\');
            location = location.Substring(0, lastIndex) + "\\Dlls";
            foreach (var dll in Directory.GetFiles(location))
            {
                Assembly assembly = Assembly.LoadFile(dll);
                IEnumerable<Type> types = assembly.GetTypes().Where(t => t.IsClass && typeof(IOperation).IsAssignableFrom(t));
                foreach (var type in types)
                {
                    dynamic instance = Activator.CreateInstance(type);
                    IOperation operation = instance as IOperation;
                    operations.Add(operation);
                }
            }
            return operations;
        }
    }
}
