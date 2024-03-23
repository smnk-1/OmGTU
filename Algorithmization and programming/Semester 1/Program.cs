using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Program 
{         
    static void Main()
    {
		// 1
		//int k = 0;
		//for (int i = 0; i < 10; i ++){
		//int n = Convert.ToInt32(Console.ReadLine());
		//if (n < 0){++k;}
		//}
		//Console.WriteLine("k = {0}", k);
		
		//2
		//int k = 0;
		//for (int i = 0; i < 10; i ++){
		//int n = Convert.ToInt32(Console.ReadLine());
		//if (n%10==3){++k;}
		//}
		//Console.WriteLine("k = {0}", k);
		
		//3
		//int k = 0;
		//for (int i = 0; i < 10; i ++){
		//int n = Convert.ToInt32(Console.ReadLine());
		//if  (n % 3 == n % 5){k += n;}
		//}
		//Console.WriteLine("k = {0}", k);
		
		//4
		//int k = 1;
		//for (int i = 0; i < 10; i ++){
		//int n = Convert.ToInt32(Console.ReadLine());
		//if (n >= 0 &&  n % 2 == 0){k *= n;}}
		//Console.WriteLine("k = {0}", k);
		
		//5
		//int k = 0;
		//int current = 0;
		//int previous =int.MinValue;	
		//int N = Convert.ToInt32(Console.ReadLine());	
		//for (int i = 0; i  < N; i ++){
		//current = Convert.ToInt32(Console.ReadLine());
		//if (current <= previous){k ++;}
		//previous = current;}
		//Console.WriteLine("k={0}", k);
		
		//6
		//int k = 0;
		//int current = 0;
		//int previous = int.MinValue;
		//int minval = int.MaxValue;
		//int N = Convert.ToInt32(Console.ReadLine());	
		//for (int i = 0; i  < N; i ++){
		//current = Convert.ToInt32(Console.ReadLine());
		//if (current <= previous && current<minval){k ++;}
		//if (current < minval){minval = current;}
		//previous = current;}
		//Console.WriteLine("k={0}", k);
		
		//7
		int k = 0;
		int current = 0;
		int previous = 0;
		int N = Convert.ToInt32(Console.ReadLine());	
		for (int i = 0; i  < N; i ++){
		current = Convert.ToInt32(Console.ReadLine());
		if ((current > 0 && 0 >previous) || (current < 0 && 0 < previous)){++k;}
		previous = current;
		}
		Console.WriteLine("k={0}", k);
    }
}
