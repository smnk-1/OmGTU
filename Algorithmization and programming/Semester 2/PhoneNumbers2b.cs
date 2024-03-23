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

        public void AddCall(string call_to, int length)
        {
            if (history.Keys.Contains(call_to))
            {
                history[call_to] += length;
            }
            else
            {
                history.Add(call_to, length);
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
            Console.WriteLine("Type: number(from)_number(to)_dd.mm_lenght or END");
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4) 
                {
                    bool check = false;
                    bool check2 = false;
                    Abonent user = new Abonent(input[0]);
                    Abonent user2 = new Abonent(input[1]);
                    foreach (Abonent oldUser in abonents)
                    {
                        if (oldUser.number == user.number)
                        {
                            check = true;
                            oldUser.AddCall(input[1], Convert.ToInt32(input[3]));
                            //Console.WriteLine("added");
                            break;
                        }
                        else if(oldUser.number == user2.number)
                        {
                            check2 = true;
                            oldUser.AddCall(input[0], Convert.ToInt32(input[3]));
                        }
                    }
                    if(check == false)
                    {
                        //Console.WriteLine("new");
                        abonents.Add(user);
                        user.AddCall(input[1], Convert.ToInt32(input[3]));
                    }
                    if (check2 == false)
                    {
                        //Console.WriteLine("new");
                        abonents.Add(user2);
                        user2.AddCall(input[0], Convert.ToInt32(input[3]));
                    }
                }
                else if(input.Length == 1)
                {
                    if (input[0] == "END") { break; }
                    else { Console.WriteLine("Input error"); }
                }
                else { Console.WriteLine("Input error"); }
            }
            Console.WriteLine("Statistics:");

            foreach (Abonent user in abonents)
            {
                Console.WriteLine($"{user.number} spoke the longest with {user.GetFrequent()}");
            }
            
        }
    }
}
