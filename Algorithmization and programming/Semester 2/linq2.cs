using System;
using System.Linq;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        List<int> ints = new List<int>() { 127, 236, 753, 987, 78, 554, 510, 930, 216, 940,
            103, 578, 362, 224, 45, 411, 77, 728, 46, 147, };

        // 1 

        var q_1 = from i in ints
                  where i % 10 % 3 == 0
                  select i;
        Console.WriteLine("Query 1:");
        foreach(int i in q_1) { Console.WriteLine(i); }

        // 2

        var q_2 = from i in ints
                  where i.ToString().Where(Char.IsDigit).Sum(Char.GetNumericValue) % 2 == 0
                  select i;
        
        Console.WriteLine("\nQuery 2:");
        foreach (int i in q_2) { Console.WriteLine(i); }

    }
}
