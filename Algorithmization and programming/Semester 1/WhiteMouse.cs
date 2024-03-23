using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Program 
{         
    static void Main()
    {
		Console.Write("Enter n: ");
		int n = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enter number of white mouse(starting with 1): ");
		int needed_mouse = Convert.ToInt32(Console.ReadLine()) - 1;
		Console.Write("Enter step(m): ");
		int step = Convert.ToInt32(Console.ReadLine());
		
		int stepped = 0;
		
		int[] mice = new int[n];
		for(int i = 0; i < n; i++)
		{
			mice[i] = 1;	
		}
		
		int current_position = needed_mouse;
	
		while(mice.Sum() > 1)
		{	
			mice[current_position] = 0;
			stepped = 0;
			
			while(stepped < step)
			{
				if(current_position - 1 >= 0)
				{
					current_position = current_position - 1;
				}
				else
				{
					current_position = current_position - 1 + n;
				}
				
				if(mice[current_position] == 1)
				{
					stepped = stepped + 1;
				}
			}
		}
		for(int j = 0; j < n; j ++)
		{
			if(mice[j]==1) Console.WriteLine("Start with: {0}", j+1);
		}
	}
}
