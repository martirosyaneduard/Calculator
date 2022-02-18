using MyProject.Operations;
using System;
using System.Collections.Generic;
using Library;

namespace MyProject.Container
{
    public class MyCalculator : IMyCalculator
    {
        private readonly IEnumerable<IOperation> _operations;
        private State _state { get; set; }
        private IOperation _operation { get; set; }
        private Dictionary<string, double> _history { get; set; }
        public MyCalculator(IEnumerable<IOperation> operations)
        {
            this._operations = operations;
            _history = new Dictionary<string, double>();
        }

        public void Start()
        {
            ChosseState();
            while (true)
            {
                PrintHistory();
                ViewOperations();
                Console.WriteLine("Input Operation Key");
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("End Program");
                    return;
                }
                foreach (var item in _operations)
                {
                    if (item.Sign == keyinfo)
                    {
                        _operation = item;
                    }
                }
                AddHistory(keyinfo);
            }

        }
        private void AddHistory(ConsoleKeyInfo keyinfo)
        {
            Console.ReadKey();
            Console.WriteLine();
            double number1 = InputNumber("Input first number!");
            double number2 = InputNumber($"Input second number!");
            double result = this.Call(number1, number2);
            string str = $"{number1} {keyinfo.KeyChar} {number2} =";
            Console.WriteLine();
            Console.WriteLine($"{str} {result}");
            try
            {
                _history.Add(str, result);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        private double Call(double x, double y)
        {
            return _operation.Operate(x, y);
        }
        private void ViewOperations()
        {
            Console.WriteLine("Chosse the one of this operations!");
            if (this._state == State.Vertical)
            {
                Console.WriteLine("1. -> /\t2. -> *\t3. -> -\t4. -> +\tExit -> Esc");
            }
            else if (this._state == State.Horizontal)
            {
                int index = 1;
                foreach (IOperation item in _operations)
                {
                    Console.Write($"{index++}.-> {item.Sign.KeyChar}\t\t");
                }
                Console.Write($"Exit -> Esc");

            }
            Console.WriteLine();
        }
        private void PrintHistory()
        {
            Console.Clear();
            Console.WriteLine("History");
            foreach (var his in _history)
            {
                Console.WriteLine($"{his.Key} {his.Value}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        private void ChosseState()
        {
            Console.WriteLine("Chosse the one of this State calculator!");
            Console.WriteLine("1. -> Vertical\t2. -> Horizontal");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    this._state = State.Vertical;
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    this._state = State.Horizontal;
                    break;
                default:
                    this._state = State.Vertical;
                    break;
            }
            Console.ReadKey();
        }
        private double InputNumber(string str)
        {
            Console.WriteLine($"{str}");
            double number;
            bool flag = double.TryParse(Console.ReadLine(), out number);
            while (!flag)
            {
                Console.WriteLine($"Wrong input try to again");
                flag = double.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }


    }
}
