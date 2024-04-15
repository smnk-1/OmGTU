using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr_1 = new StreamReader(@"D:\Projects\ConsoleApplication22\input1_1.txt");
            StreamReader sr_2 = new StreamReader(@"D:\Projects\ConsoleApplication22\input1_2.txt");

            int data1 = Convert.ToInt32(sr_1.ReadLine());
            int data2 = Convert.ToInt32(sr_2.ReadLine());
            int check = 0;
            while(true)
            {
                if (data1 < data2)
                {
                    Console.WriteLine(data1);
                    string read1 = sr_1.ReadLine();
                    if(read1 != null)
                    {
                        data1 = Convert.ToInt32(read1);
                    }
                    else { check = 1;  break; }
                    
                }
                else
                {
                    Console.WriteLine(data2);
                    string read2 = sr_2.ReadLine();
                    if (read2 != null)
                    {
                        data2 = Convert.ToInt32(read2);
                    }
                    else { check = 2; break; }
                }
            }
            
            if(check == 2)
            {
                Console.WriteLine(data1);
                while(true)
                {
                    string read1 = sr_1.ReadLine();
                    if (read1 != null)
                    {
                        data1 = Convert.ToInt32(read1);
                        Console.WriteLine(data1);
                    }
                    else { break; } 
                }
            }

            else if(check == 1)
            {
                Console.WriteLine(data2);
                while(true)
                {
                    string read2 = sr_2.ReadLine();
                    if (read2 != null)
                    {
                        data2 = Convert.ToInt32(read2);
                        Console.WriteLine(data2);
                    }
                    else { break; }
                }
            }

            Console.ReadKey();
        }
    }
}
