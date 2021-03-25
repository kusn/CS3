//Кудряшов Сергей

//2. *В некой директории лежат файлы. По структуре они содержат 3 числа, разделенные пробелами.
//Первое число — целое, обозначает действие, 1 — умножение и 2 — деление, остальные два — числа с плавающей точкой.
//Написать многопоточное приложение, выполняющее вышеуказанные действия над числами и сохраняющее результат в файл result.dat.
//Количество файлов в директории заведомо много.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ParsingFiles
{
    class Program
    {
        static string folder = "..\\..\\Files";
        static Random rnd = new Random();
        static object locker = new object();
        static string flresult = $"{folder}\\result.dat";

        static void Main(string[] args)
        {
            Task[] tasksGetFiles = new Task[10];
            
            if (File.Exists(flresult))
            {
                File.Delete(flresult);
            }

            // Создаём файлы
            for (int i = 0; i < tasksGetFiles.Length; i++)
            {
                string file = $"{folder}\\file({i}).txt";

                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                tasksGetFiles[i] = Task.Factory.StartNew(() => GetFiles(file));
            }
            Task.WaitAll(tasksGetFiles);

            //Работаем с файлами            
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            if (directoryInfo.GetFiles().Length == 0)
                Console.WriteLine("В папке отсутствуют файлы");
            else
            {
                foreach (FileInfo fileToParse in directoryInfo.GetFiles())
                {
                    Task.Factory.StartNew(() => ParseFile(fileToParse.FullName));
                }
            }


            Console.ReadLine();
        }

        // Заполняем файл данными
        static void GetFiles(string file)
        {
            lock (locker)
            {
                using (StreamWriter sw = new StreamWriter(file, false, Encoding.Default))
                {
                    string text = rnd.Next(1, 3).ToString() + " " + (rnd.Next(0, 100) / 10.0).ToString() + " " + (rnd.Next(0, 100) / 10.0).ToString();
                    sw.Write(text);
                    Console.WriteLine($"Создан файл {file} с текстом: {text}");
                }
            }
        }

        // Разбираем файл и записываем результат
        static void ParseFile(string file)
        {
            lock (locker)
            {
                double result = new double();

                using (StreamReader sr = new StreamReader(file))
                {
                    string strresult = "";
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string[] str = sr.ReadLine().Split(' ');
                            if (str[0] == "1")
                            {
                                result = Convert.ToDouble(str[1]) * Convert.ToDouble(str[2]);
                                strresult = "Умножение";
                            }
                            else if (str[0] == "2")
                            {
                                result = Convert.ToDouble(str[1]) / Convert.ToDouble(str[2]);
                                strresult = "Деление";
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        Console.WriteLine($"Действие: {strresult}. Результат: {result}");
                    }
                }
                
                using (StreamWriter sw = new StreamWriter(flresult, true, Encoding.Default))
                {
                    sw.WriteLine(result);
                    Console.WriteLine($"Результат записан в файл {flresult}");
                }
            }
        }
    }
}
