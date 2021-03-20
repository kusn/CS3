﻿//Кудряшов Сергей

//1. Написать приложение, считающее в раздельных потоках:
//a.факториал числа N, которое вводится с клавиатуру;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FactorialMultiThread
{
    class Program
    {
        static double fact = 1;
        static object locker = new object();

        static void Main(string[] args)
        {
            int n;
            int processorCount = System.Environment.ProcessorCount;
            int part;
            

            Console.WriteLine("Введите число, для которого нужно посчитать факториал");
            Int32.TryParse(Console.ReadLine(), out n);
            InitialData initialData = new InitialData
            {
                Start = 0,
                Finish = n
            };

            part = initialData.Finish / processorCount;

            DateTime startTime = DateTime.Now;
            if (part == 0)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Factorial))
                {
                    Name = "0"
                };
                Console.WriteLine("---Запустился поток: " + thread.Name);
                thread.Start(initialData);
            }
            else if (part != 0)
            {
                for (int i = 0; i < processorCount; i++)
                {
                    InitialData id = new InitialData();
                    if ((i + 1) != processorCount)
                    {
                        id.Start = (part * i) + 1;
                        id.Finish = part * (i + 1);
                    }
                    else
                    {
                        id.Start = (part * i) + 1;
                        id.Finish = initialData.Finish;
                    }

                    Thread thread = new Thread(new ParameterizedThreadStart(Factorial))
                    {
                        Name = (i).ToString()
                    };

                    Console.WriteLine("---Запустился поток: " + thread.Name);
                    thread.Start(id);                    
                }
            }
            Console.WriteLine(System.Environment.NewLine + $"Время выполнения в мультипотоке: {DateTime.Now - startTime}");

            Thread.Sleep(5000);     // Почему-то нужно делать задержку, для правильного вывода следующей строчки
            Console.WriteLine();
            Console.WriteLine(System.Environment.NewLine + $"Итоговый факториал равен: {fact}");

            Thread.Sleep(5000);
            fact = 1;            
            Console.WriteLine(System.Environment.NewLine);
            startTime = DateTime.Now;
            Factorial(initialData);
            Console.WriteLine(System.Environment.NewLine + $"Время выполнения в однопотоке: {DateTime.Now - startTime}");

            Console.ReadLine();
        }

        static void Factorial(object obj)
        {
            lock (locker)
            {
                InitialData initialData = (InitialData)obj;
                double tFact = 1;
                int start = initialData.Start;

                if (start == 0)
                    start = 1;

                if (initialData.Finish == 0) tFact = 1;

                else for (int i = start; i <= initialData.Finish; i++)
                        tFact = tFact * i;

                Console.WriteLine($"Частичный факториал между числами от {initialData.Start} до  {initialData.Finish} равен: {tFact}");
                fact = fact * tFact;
                Console.WriteLine($"Факториал равен: {fact}");
            }
        }

        public class InitialData
        {
            public int Start { get; set; }
            public int Finish { get; set; }            
        }
    }
}
