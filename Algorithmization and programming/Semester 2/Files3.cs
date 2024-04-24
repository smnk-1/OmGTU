using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> usedSymbols = new Dictionary<char,int>();
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\ConsoleApplication6\Input.txt");
            while(true)
            {
                string data = sr.ReadLine();
                if(data != null)
                {
                    foreach(char s in data)
                    {
                        if(usedSymbols.ContainsKey(s))
                        {
                            usedSymbols[s] += 1;
                        }
                        else { usedSymbols.Add(s, 1); }
                    }
                }
                else {break;}
            }

            int maxCount = 0;
            char mostFrequent = ' ';
            foreach (var symb in usedSymbols.Keys)
            {
                if (usedSymbols[symb] > maxCount)
                {
                    maxCount = usedSymbols[symb];
                    mostFrequent = symb;
                }
            }
            Console.WriteLine("Most frequent: " + mostFrequent);

            var used = usedSymbols.Keys.OrderBy(x => x);

            Console.WriteLine("Used " + Convert.ToString(usedSymbols.Keys.Count) + " symbols");

            Console.Write("All used: ");
            foreach(var s in used)
            {
                Console.Write(s + " ");
            }
            Console.ReadKey();
        }
    }
}
