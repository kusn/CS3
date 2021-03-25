//Кудряшов Сергей

//1. Даны 2 двумерных матрицы. Размерность 100х100 каждая.
//Напишите приложение, производящее параллельное умножение матриц.
//Матрицы заполняются случайными целыми числами от 0 до10.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MatrixMultiplication
{
    class Program
    {
        static Random rnd = new Random();
        static int leng = 3;
        static int[,] matrix1 = new int[leng, leng];
        static int[,] matrix2 = new int[leng, leng];
        static int[,] resultMatrix = new int[leng, leng];
        static object locker = new object();

        static void Main(string[] args)
        {
            
            matrix1 = GetMatrix();
            matrix2 = GetMatrix();

            Console.WriteLine("Первая матрица: ");
            ScreenMatrix(matrix1);
            Console.WriteLine("Вторая матрица: ");
            ScreenMatrix(matrix2);

            Console.WriteLine("Результат умножения матриц:");
            Parallel.For(0, leng, MatrixMulti);

            Console.ReadLine();
        }

        static int[,] GetMatrix()
        {
            int[,] matrix = new int[leng, leng];
            for(int i = 0; i < leng; i++)
                for(int j = 0; j < leng; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10); 
                }
            return matrix;
        }

        static void ScreenMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < matrix.GetLength(1) - 1)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.WriteLine(matrix[i, j]);
                }
        }

        static void MatrixMulti(int index)
        {            
            //lock(locker)
            for (int j = 0; j < leng; j++)
            {
                int result = 0;
                for (int i = 0; i < leng; i++)
                {
                    result = result + matrix1[index, i] * matrix2[i, index];
                }
                resultMatrix[index, j] = result;

                if (j < leng - 1)
                    Console.Write(resultMatrix[index, j] + " ");
                else
                    Console.WriteLine(resultMatrix[index, j]);
               
            }
        }
    }
}
