// Кудряшов Сергей

// 1. Написать приложение, считающее в раздельных потоках:
// 2. *Написать приложение, выполняющее парсинг CSV-файла произвольной структуры и сохраняющее его в обычный TXT-файл.
// Все операции проходят в потоках. CSV-файл заведомо имеет большой объём.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace CsvToTxtMultiThread
{
    class Program
    {
        static string csvFileName = "..//..//students_6.csv";
        static string txtFileName = "..//..//students_6.txt";
        static object locker = new object();
        
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(csvFileName);

            if (File.Exists(txtFileName))
            {
                File.Delete(txtFileName);
            }    

                while (!sr.EndOfStream)
            {
                try
                {
                    string s = sr.ReadLine();

                    Thread thread = new Thread(new ParameterizedThreadStart(CsvToTxt));
                    thread.Start(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            sr.Close();
        }

        static void CsvToTxt(object obj)
        {
            lock(locker)
            {
                string s = (string)obj;

                using (StreamWriter sw = new StreamWriter(txtFileName, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(s);
                }
            }
        }
    }
}
