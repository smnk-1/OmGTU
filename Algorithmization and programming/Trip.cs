using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Program
{
	static void Main()
	{
		int days = 1;
		Console.Write("Speed: ");
		double speed = Convert.ToDouble(Console.ReadLine());
		speed = speed*1000/60;
		
		Console.WriteLine("Voshod");
		Console.Write('\t' + "Hours: ");
		int voshod_h = Convert.ToInt32(Console.ReadLine());
		Console.Write('\t' + "Minutes: ");
		int voshod_m = Convert.ToInt32(Console.ReadLine());
		int voshod_time = 60*voshod_h + voshod_m;
		
		Console.WriteLine("Zakat");
		Console.Write('\t' + "Hours: ");
		int zakat_h = Convert.ToInt32(Console.ReadLine());
		Console.Write('\t' + "Minutes: ");
		int zakat_m = Convert.ToInt32(Console.ReadLine());
		int zakat_time = 60*zakat_h+zakat_m;
		
		double day_time_min = zakat_time - voshod_time;
		
		Console.Write("Number: ");
		int n = Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine("Pouncts:");
		
		double [] pountcs = new double [n];
		
		for(int i = 0; i < n; i++)
		{
		    pountcs[i] = 1000*Convert.ToDouble(Console.ReadLine());
		}
		
		for(int i = 1; i < n; i ++)
		{
		 pountcs[i] = pountcs[i]-pountcs[i-1];
		}
		
		double current_dist = 0;
		double current_time = 0;
		
		for(int i = 0; i < n; i ++)
		{					
		    if((pountcs[i])/speed <= day_time_min-current_time)
			{
			    current_dist += pountcs[i];
				current_time += (pountcs[i])/speed;
			}
			else
			{	
				days += 1;
				current_dist = 0;
			    current_time = 0;
			    Console.WriteLine($"Stopped at p. {i}");
			}
		}
		Console.WriteLine($"Days: {days}");
	}
}
