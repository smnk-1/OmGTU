using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
class Program
{	 
	static void Main()
	{	
        Dictionary<string, int> numbers = new Dictionary<string, int>();
		Queue<string[]> q = new Queue<string[]>();
		Console.Write("How many numbers? ");
		int n = Convert.ToInt32(Console.ReadLine());
		for(int i = 0; i < n; i ++)
		{
            string[] s = Console.ReadLine().Split(' '); // 888888888 21.02.21 16:20 89
			q.Enqueue(s);
        }
		for(int i = 0; i < n; i ++)
		{
            string[] current = q.Dequeue();
            if(numbers.ContainsKey(current[1])==false)
			{
                numbers.Add(current[1], Convert.ToInt32(current[3]));
			}
			else
			{
                numbers[current[1]] += Convert.ToInt32(current[3]);
            }
        }
		foreach(var num in numbers)
		{
            Console.WriteLine($"date: {num.Key} minutes: {num.Value}");
        }
	}
}
