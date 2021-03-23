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
        static int[,] matrix1 = new int[100, 100];
        static int[,] matrix2 = new int[100, 100];
        static int[,] resultMatrix = new int[100, 100];

        static void Main(string[] args)
        {
            
            matrix1 = GetMatrix();
            matrix2 = GetMatrix();

            Console.WriteLine("Первая матрица: ");
            ScreenMatrix(matrix1);
            Console.WriteLine("Вторая матрица: ");
            ScreenMatrix(matrix2);

            Console.ReadLine();
        }

        static int[,] GetMatrix()
        {
            int[,] matrix = new int[100, 100];
            for(int i = 0; i < 100; i++)
                for(int j = 0; j < 100; j++)
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

        static int[,] MatrixMulti(int[,] matrix1, int[,] matrix2)
        {
            int[,] result = new int[100, 100];



            return result;

        }
    }
}
