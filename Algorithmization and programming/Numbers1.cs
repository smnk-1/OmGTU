using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

class Program
{
        
	static void Main()
	{
        // dict
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
            if(numbers.ContainsKey(current[0])==false)
			{
                numbers.Add(current[0], Convert.ToInt32(current[3]));
			}
			else
			{
                numbers[current[0]] += Convert.ToInt32(current[3]);
            }
        }
	
		foreach(var num in numbers)
		{
            Console.WriteLine($"number: {num.Key} minutes: {num.Value}");
        }
		
		// hashtable
		Hashtable numbers2 = new Hashtable();
		Queue<string[]> q2 = new Queue<string[]>();
		Console.Write("How many numbers? ");
		int n2 = Convert.ToInt32(Console.ReadLine());
		
		for(int i = 0; i < n2; i ++)
		{
            string[] s = Console.ReadLine().Split(' '); // 888888888 21.02.21 16:20 89
			q2.Enqueue(s);
        }
		
		for(int i = 0; i < n2; i ++)
		{
            string[] current = q2.Dequeue();
            if(numbers2.ContainsKey(current[0])==false)
			{
                numbers2.Add(current[0], Convert.ToInt32(current[3]));
			}
			else
			{
                numbers2[current[0]] = Convert.ToInt32(numbers2[current[0]])+Convert.ToInt32(current[3]);
            }
        }
		foreach(DictionaryEntry num in numbers2)
		{
            Console.WriteLine($"number: {num.Key} minutes: {num.Value}");
        }
	}
}
