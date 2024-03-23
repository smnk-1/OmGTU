using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneNubmersTask2
{
    class Abonent
    {
        public string number;
        public Dictionary<string, int> history = new Dictionary<string, int>();
        public Abonent(string number)
        {
            this.number = number;
        }

        public void AddCall(string call_to)
        {
            if (history.Keys.Contains(call_to))
            {
                history[call_to] += 1;
            }
            else
            {
                history.Add(call_to, 1);
            }
        }

        public string GetFrequent()
        {
            int maxValuse = history.Values.Max();
            foreach(var key in history.Keys) 
            {
                if(history[key] == maxValuse) { return key; break; }
            }
            return "contain error";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Abonent> abonents = new List<Abonent>();
            Console.WriteLine("Type: number(from)_number(to)_dd.mm_000lenght or END");
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4) 
                {
                    bool check = false;
                    Abonent user = new Abonent(input[0]);
                    foreach(Abonent oldUser in abonents)
                    {
                        if(oldUser.number == user.number)
                        {
                            check = true;
                            oldUser.AddCall(input[1]);
                            //Console.WriteLine("added");
                            break;
                        }
                    }
                    if(check == false)
                    {
                        //Console.WriteLine("new");
                        abonents.Add(user);
                        user.AddCall(input[1]);
                    }
                }
                else if(input.Length == 1)
                {
                    if (input[0] == "END") { break; }
                    else { Console.WriteLine("Input error"); }
                }
                else { Console.WriteLine("Input error"); }
            }
            Console.WriteLine("Enter needed number or END");
            while (true)
            {
                string neededUser = Console.ReadLine();
                if(neededUser != "END")
                {
                    bool check = false;
                    foreach (Abonent user in abonents)
                    {
                        if (user.number == neededUser)
                        {
                            check = true;
                            Console.WriteLine("The most frequent: " + user.GetFrequent());
                            break;
                        }
                    }
                    if (check == false) { Console.WriteLine("There is no such number, try again"); }
                }
                else {break;}
            }
        }
    }
}
