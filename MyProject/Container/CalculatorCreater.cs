using MyProject.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Library;

namespace MyProject.Container
{
    class CalculatorCreater : ICalculatorCreator
    {
        private const string Path = @"C:\Plugins";
        public CalculatorCreater()
        {
            CheckDirectory();
        }
        private void CheckDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Plugins");
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
        public IMyCalculator CreateCalculator()
        {
            List<IOperation> _defaultOperations = new List<IOperation>();
            IEnumerable<IOperation> operations = GetOperations();
            _defaultOperations.Add(new SumOperation());
            _defaultOperations.Add(new SubtractOperation());
            _defaultOperations.Add(new DivideOperation());
            _defaultOperations.Add(new MultiplyOperation());
            _defaultOperations.AddRange(operations);
            return new MyCalculator(_defaultOperations);
        }

        public IEnumerable<IOperation> GetOperations()
        {
            //1.version
            var pluginFiles = Directory.GetFiles(Path, "*.dll");
            IEnumerable<IOperation> loaders = (from file in pluginFiles
                                               let asm = Assembly.LoadFile(file)
                                               from type in asm.GetTypes()
                                               where typeof(IOperation).IsAssignableFrom(type)
                                               select (IOperation)Activator.CreateInstance(type)).ToList();

            return loaders;
            //2.version
            //List<IOperation> operations = new List<IOperation>();
            //foreach (var dll in Directory.GetFiles(Path))
            //{
            //    Assembly assembly = Assembly.LoadFile(dll);
            //    IEnumerable<Type> types = assembly.GetTypes().Where(t => t.IsClass && typeof(IOperation).IsAssignableFrom(t));
            //    foreach (var type in types)
            //    {
            //        dynamic instance = Activator.CreateInstance(type);
            //        IOperation operation = instance as IOperation;
            //        operations.Add(operation);
            //    }
            //}
            //return operations;
        }
    }
}
