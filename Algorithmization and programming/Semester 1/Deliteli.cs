using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Program
{	
	static void Main()
	{
	    int s1 = 106732567;
		int f1 = 152673836;
	
	    for(int x = s1; x <= f1; x++)
		{
		    int count = 0;
		    int max_d = int.MinValue;
		    if(Math.Sqrt(x) == (int)Math.Sqrt(x))
			{
			    int d = 2;
				while(d*d < x)
			    {
			    if(x % d == 0)
					{
						count += 2;
					    max_d = Math.Max(max_d, d);
					    max_d = Math.Max(max_d, x/d);
				    }
				    d ++;
			    }
			    if(d*d == x){max_d = Math.Max(max_d, d); count += 1;}
			
			    if(count == 3){Console.WriteLine($"{x}: {max_d}");} 			
			}
		    
		}
	}
}
