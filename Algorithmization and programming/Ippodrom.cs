using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ippodrom
{
    internal class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("Horses:");
                Console.WriteLine("  " + "1. Olivia");
                Console.WriteLine("  " + "2. Max");
                Console.WriteLine("  " + "3. Antony");

                int n = 0;
                while (n != 1 & n != 2 & n != 3) 
                {
                    Console.Write("Which one do you prefer? ");
                    string try_n = Console.ReadLine();
                    bool check_n = true;
                    foreach (char value in try_n)
                    {
                        bool digit = char.IsDigit(value);
                        if (digit==false) { check_n = false; }
                    }
                    if(check_n == true)
                    {
                        n = Convert.ToInt32(try_n); 
                    }  
                }

                Random rnd = new Random();
                int[] speed = { rnd.Next(1, 1000), rnd.Next(1, 1000), rnd.Next(1, 1000) };
                int max_speed = Math.Max(Math.Max(speed[0], speed[1]), speed[2]);
                int win = 0;
                for(int i = 0; i < 3; i++) { if (speed[i] == max_speed) { win = i + 1; break; } }

                Console.WriteLine($"Horse number {win} have won");
                if (n == win)
                {
                    Console.WriteLine("Congratulations! You've won :)");
                }
                else
                {
                    Console.WriteLine("Sorry, you've lost :(");
                }

                string c = " ";
                while(c != "Y" & c != "N") 
                {
                    Console.Write("Write Y if you want to play again, N if you don't: ");
                    c = Console.ReadLine();
                }
                if(c == "N"){ break; }
            }
        }
    }
}
