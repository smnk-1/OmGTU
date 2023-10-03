using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Program 
{         
    static void Main()
    {
		int sum = 0;
		int[] min_d1 = {Int32.MaxValue, Int32.MaxValue};
		int[] min_d2 = {Int32.MaxValue, Int32.MaxValue};
		Console.WriteLine("Enter N");
		int n = Convert.ToInt32(Console.ReadLine());
		int x;
		int y;
		for(int i = 0; i < n; i++)
		{
			Console.WriteLine("Pair {0}:", i+1);
			x = Convert.ToInt32(Console.ReadLine());
			y = Convert.ToInt32(Console.ReadLine());
			
			int dif = Math.Abs(x-y);
			
			if(dif % 3 == 1){
				if(dif < min_d1[0]){
					min_d1[0] = dif;
				}
				else if(dif < min_d1[1]){
					min_d1[1] = dif;
				}
			}
			else if(dif % 3 == 2){
				if(dif < min_d2[0]){
					min_d2[0] = dif;
				}
				else if(dif < min_d2[1]){
					min_d2[1] = dif;
				}
			}
			
			sum += Math.Max(x, y);
		}
		
		bool test1 = (min_d1[0]<Int32.MaxValue || min_d1[1]<Int32.MaxValue) || (min_d2[0]<Int32.MaxValue && min_d2[1]<Int32.MaxValue);
		bool test2 = (min_d2[0]<Int32.MaxValue || min_d2[1]<Int32.MaxValue) || (min_d1[0]<Int32.MaxValue && min_d1[1]<Int32.MaxValue);
		
		if (sum % 3 == 0) Console.WriteLine("Max sum: {0}", sum);
		else if (sum % 3 == 1 && test1){
			int r1 = ((min_d1[0] < min_d1[1]) ? min_d1[0] : min_d1[1]);
			int min = r1;
			
			if (min_d2[0] < Int32.MaxValue && min_d2[1] < Int32.MaxValue){
			int r2 = min_d2[0] + min_d2[0]; //
			min = (min < r2 ? min : r2);	
			}
			if (min < Int32.MaxValue){
				sum = sum - min;
			}
			Console.WriteLine("Max sum: {0}", sum);
			
		}
		else if(sum % 3 == 2 && test2){
			int r2 = ((min_d2[0] < min_d2[1]) ? min_d2[0] : min_d2[1]);
			int min = r2;
			
			if (min_d1[0] < Int32.MaxValue && min_d1[1] < Int32.MaxValue){
				int r1 = min_d1[0] + min_d1[0];
				min = (min < r1 ? min : r1);
			}
			if (min < Int32.MaxValue){
				sum = sum - min;
			}
			Console.WriteLine("Max sum: {0}", sum);
		 }
		else{Console.WriteLine("No possible sum");}
	}
}