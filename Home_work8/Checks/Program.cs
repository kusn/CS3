using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checks
{
    class Program
    {
        private enum SomeEnum
        {
            First = 4,
            Second,
            Third,
            Fourth = 7
        }

        static void Main(string[] args)
        {
            // 2. Есть ли проблемы в следующем коде?
            /*int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(obj);
            Console.WriteLine((short)obj);*/

            // 4. Каков результат вывода следующего кода?
            Console.WriteLine((int)SomeEnum.Second);
            Console.WriteLine((int)SomeEnum.Third);

            Console.ReadLine();
        }
    }
}
