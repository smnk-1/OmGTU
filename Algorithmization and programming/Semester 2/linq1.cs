using System;
using System.Linq;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        List<string> lst = new List<string>() { "a", "aa", "bb", "ccc", "ddd", "avav", "tytg" };
        Console.WriteLine("Test 1");

        Console.Write("List: ");

        foreach (string s in lst)
        {
            Console.Write($"{s} ");
        }

        var q_1 = from s in lst
                  where s.Length % 2 == 0
                  select s;


        foreach (string s in q_1)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("\nTest 2");

        int c = 0;
        for (int i = 0; i < lst.Count(); i++)
        {
            if (i % 2 == 0)
            {
                lst.RemoveAt(i - c);
            }

        }

        Console.Write("List: ");
        foreach (string s in lst)
        {
            Console.Write($"{s} ");
        }

        foreach (string s in q_1)
        {
            Console.WriteLine(s);
        }
    }
}
