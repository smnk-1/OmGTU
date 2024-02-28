using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Дан двумерный массив MxN, необходимо:
// 1. Определить в каждой строке максимальный отрицательный элемент
// 2. Определить в каждом столбце кол-во элементов, отличных от минимального
// элемента массива
// 3. Заменить элементы строки с наибольшей суммой четных элементов на
// единички, если таких строк несколько, заменить в каждой строке элементы

namespace Matrix
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("M(строки): ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("N(столбцы): ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[M, N];
            for (int i = 0; i < M; i++) 
            {
                for(int j = 0; j < N; j ++)
                {
                    matrix[i , j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Matrix:");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Task 1");

            int[] max_below_zero = new int[M];
            for (int i = 0; i < M; i++)
            {
                int max_bz = int.MinValue;
                for (int j = 0; j < N; j++)
                {
                    if(matrix[i, j] < 0 & matrix[i,j] > max_bz) { max_bz = matrix[i, j]; }
                }
                max_below_zero[i] = max_bz;
            }
            for(int i = 0; i < M; i++) 
            { 
                if (max_below_zero[i] > int.MinValue) 
                {
                    Console.WriteLine($"{i + 1}) {max_below_zero[i]}");
                } 
                else
                {
                    Console.WriteLine($"{i + 1}) None");
                }
            }

            Console.WriteLine("Task 2");

            int min_v = int.MaxValue;
            for (int i = 0; i < M; i++)
            {  
                for (int j = 0; j < N; j++)
                {
                    min_v = Math.Min(matrix[i, j], min_v);
                }
            }
            Console.WriteLine($"Min value: {min_v}");
            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                counter = 0;
                for (int j = 0; j < M; j++)
                {
                    if (matrix[j, i] != min_v) { counter += 1; }
                }
                Console.WriteLine($"{i + 1}: {counter}");
            }

            Console.WriteLine("Task 3");

            int[] sum_chet  = new int [M];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] % 2 == 0) { sum_chet[i] += matrix[i, j]; }
                }
            }
            int max_sum = sum_chet.Max();
            bool[] change = new bool[M];
            
            for(int i = 0; i < M; i ++) 
            {
                if (sum_chet[i] == max_sum) { change[i] = true; }
            }
            
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (change[i]) { matrix[i, j] = 1; }
                }
            }
            
            Console.WriteLine("Matrix:");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
