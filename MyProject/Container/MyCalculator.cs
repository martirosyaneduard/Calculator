using MyProject.Operations;
using System;
using System.Collections.Generic;

namespace MyProject.Container
{
    public class MyCalculator
    {
        private State _state { get; set; }
        private IOperation _operation { get; set; }
        private Dictionary<string, double> _history { get; set; }
        public MyCalculator()
        {
            _history = new Dictionary<string, double>();
            _state = State.Vertical;
        }

        public void Start()
        {
            char sign = ' ';
            ChosseState();
            while (true)
            {
                PrintHistory();
                ViewOperations();
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Divide:
                        _operation = new DivideOperation();
                        sign = '/';
                        break;
                    case ConsoleKey.Multiply:
                        _operation = new MultiplyOperation();
                        sign = '*';
                        break;
                    case ConsoleKey.Subtract:
                        _operation = new SubtractOperation();
                        sign = '-';
                        break;
                    case ConsoleKey.Add:
                        _operation = new SumOperation();
                        sign = '+';
                        break;
                    case ConsoleKey.D5:
                        _operation = new RemainderOperation();
                        sign = '%';
                        break;
                    case ConsoleKey.Escape:
                        Console.ReadKey();
                        return;
                    default:
                        WrongInput();
                        break;
                }
                AddHistory(sign);
            }
        }
        private void AddHistory(char sign)
        {
            double number1 = InputNumber("Input first number!");
            double number2 = InputNumber($"Input second number!");
            double item = this.Call(number1, number2);
            string str = $"{number1} {sign} {number2} =";
            Console.WriteLine();
            Console.WriteLine($"{str} {item}");
            try
            {
                _history.Add(str, item);
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
                Console.WriteLine("1. -> /\t2. -> *\t3. -> -\t4. -> +\t5. -> %\tExit -> Esc");
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
                    WrongInput();
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
        private void WrongInput()
        {
            Console.Clear();
            Console.WriteLine("Wrong Input:Try to again.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
