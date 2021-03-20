using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialMultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int processorCount = System.Environment.ProcessorCount;

            Console.WriteLine("Введите число, для которого нужно посчитать факториал");
            Int32.TryParse(Console.ReadLine(), out n);



            Console.WriteLine(Factorial(n).ToString());

            Console.ReadLine();
        }

        static double Factorial(int n)
        {
            double fact = 1;
            
            if (n == 0) return 1;
            for (int i = 1; i <= n; i++)
                fact = fact * i;

            return fact;
        }
    }
}
