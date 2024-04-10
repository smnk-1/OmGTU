using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            string[] file_input = File.ReadAllLines(@"C:\Users\User\Desktop\ConsoleApplication5\input.txt");
            
            string[,] result = new string[file_input.Length, 3];
            for(int i = 0; i < file_input.Length; i ++)
            {
                string[] s = file_input[i].Split(' ');
                for(int j = 0; j < 3; j ++)
                {
                    result[i, j] = s[j];
                }
            }
            // output
            for (int i = 0; i < file_input.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + ' ');
                }
                Console.WriteLine(" ");
            }
            // sorting 1
            bool check = true;
            while (check)
            {
                check = false;
                for (int i = 0; i < result.GetLength(0) - 1; i++)
                {
                    if (Convert.ToInt32(result[i, 0]) > Convert.ToInt32(result[i + 1, 0]))
                    {
                        check = true;
                        string[] temp = new string[result.GetLength(1)];
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            temp[j] = result[i, j];
                        }
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            result[i, j] = result[i + 1, j];
                        }
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            result[i + 1, j] = temp[j];
                        }
                    }
                }
            }
            
            // output 1
            Console.WriteLine("Sorted");
            StreamWriter writer = File.CreateText(@"C:\Users\User\Desktop\ConsoleApplication5\output1.txt");
            for (int i = 0; i < file_input.Length; i++)
            {
                string[] temp = new string[result.GetLength(1)];
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    temp[j] = result[i, j];
                }
                Console.WriteLine(String.Join(" ", temp));
                writer.WriteLine(String.Join(" ", temp));
            }
            writer.Close();
            
            // sorting 2 
            check = true;
            while (check)
            {
                check = false;
                for (int i = 0; i < result.GetLength(0) - 1; i++)
                {
                    if (String.Compare(result[i, 1], result[i + 1, 1]) > 0)
                    {
                        check = true;
                        string[] temp = new string[result.GetLength(1)];
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            temp[j] = result[i, j];
                        }
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            result[i, j] = result[i + 1, j];
                        }
                        for (int j = 0; j < result.GetLength(1); j++)
                        {
                            result[i + 1, j] = temp[j];
                        }
                    }
                }
            }

            // output 2
            Console.WriteLine("Sorted 2");
            writer = File.CreateText(@"C:\Users\User\Desktop\ConsoleApplication5\output2.txt");
            for (int i = 0; i < file_input.Length; i++)
            {
                string[] temp = new string[result.GetLength(1)];
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    temp[j] = result[i, j];
                }
                Console.WriteLine(String.Join(" ", temp));
                writer.WriteLine(String.Join(" ", temp));
            }
            writer.Close();
            
            // sorting + ouptut 3
            Console.Write("Enter country: ");
            string country = Console.ReadLine().ToLower();
            writer = File.CreateText(@"C:\Users\User\Desktop\ConsoleApplication5\output3.txt");
            for(int i = 0; i < result.GetLength(0) - 1; i++)
            {
                if(result[i, 2] == country)
                {
                    string[] temp = new string[result.GetLength(1)];
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        temp[j] = result[i, j];
                    }
                    Console.WriteLine(String.Join(" ", temp));
                    writer.WriteLine(String.Join(" ", temp));
                }
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
