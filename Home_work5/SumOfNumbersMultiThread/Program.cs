//Кудряшов Сергей

//1. Написать приложение, считающее в раздельных потоках:
//b. сумму целых чисел до N, которое также вводится с клавиатуры.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SumOfNumbersMultiThread
{
    class Program
    {
        static double sum = 0;
        static object locker = new object();

        static void Main(string[] args)
        {
            int n;
            int processorCount = System.Environment.ProcessorCount;
            int part;


            Console.WriteLine("Введите число: ");
            Int32.TryParse(Console.ReadLine(), out n);
            InitialData initialData = new InitialData
            {
                Start = 0,
                Finish = n
            };

            part = initialData.Finish / processorCount;

            if (part == 0)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(SumOfNamber))
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

                    Thread thread = new Thread(new ParameterizedThreadStart(SumOfNamber))
                    {
                        Name = (i).ToString()
                    };

                    Console.WriteLine("---Запустился поток: " + thread.Name);
                    thread.Start(id);
                }
            }
            Thread.Sleep(1000);     // Почему-то нужно делать задержку, для правильного вывода следующей строчки
            Console.WriteLine();
            Console.WriteLine($"Итоговая сумма равна: {sum}");

            Console.ReadLine();
        }

        static void SumOfNamber(object obj)
        {
            lock (locker)
            {
                InitialData initialData = (InitialData)obj;
                double tSum = 0;
                int start = initialData.Start;                

                for (int i = start; i <= initialData.Finish; i++)
                        tSum = tSum + i;

                Console.WriteLine($"Сумма между числами от {initialData.Start} до  {initialData.Finish} равна: {tSum}");
                sum = sum + tSum;
                Console.WriteLine($"Сумма равна: {sum}");
            }
        }

        public class InitialData
        {
            public int Start { get; set; }
            public int Finish { get; set; }
        }
    }
}
