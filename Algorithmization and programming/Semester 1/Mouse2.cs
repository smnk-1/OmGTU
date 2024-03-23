using System;
using System.Linq;
class WhiteMiceTwo {
    public static void Main() 
    {
        Console.Write("Grey: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("White: ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("K: ");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.Write("Grey left: ");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("White left: ");
        int m1 = Convert.ToInt32(Console.ReadLine());

        int remainder = n1 + m1;

        int[] mice = new int[n + m];
        for (int i = 0; i < mice.Length; i++) 
        {
            mice[i] = 1;
        }

        int pointer = 0;

        while (mice.Count(c => c == 1) > remainder) 
        {
            int moved = 0;
            while (moved != k) 
            {
                ++pointer;
                if (pointer > mice.Length - 1) 
                {
                    pointer = 0;
                }
                if (mice[pointer] == 1) 
                {
                    ++moved;
                }
            }
            mice[pointer] = 0;
        }

        int placed_n = 0;
        int placed_m = 0;
        int placed_alive_n = 0;
        int placed_alive_m = 0;

        if (n - n1 == 0 || m - m1 == 0) 
        {
            Console.WriteLine("Impossible task");
        } 
        else 
        {
            for (int i = 0; i < mice.Length; i++) 
            {
                if (mice[i] == 0) 
                {
                    if (placed_n < n - n1) 
                    {
                        Console.WriteLine("Grey");
                        placed_n++;
                    } 
                    else if (placed_m < m - m1) 
                    {
                        Console.WriteLine("White");
                        placed_m++;
                    }
                }  
                else if (mice[i] == 1) 
                {
                    if (placed_alive_n < n1) 
                    {
                        Console.WriteLine("Grey");
                        placed_alive_n++;
                    } 
                    else if (placed_alive_m < m1) 
                    {
                        Console.WriteLine("White");
                        placed_alive_m++;
                    }
                } 
            }
        }
    }
}
