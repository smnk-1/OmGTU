using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;
using System.Collections;


class Program
{
	static void Main()
	{
	    Console.WriteLine("Array");
		Console.Write("Enter array lenght (>1): ");
		int len = Convert.ToInt32(Console.ReadLine());
		int[] ar = new int[len];
		for(int i = 0; i < len; i ++)
		{
		    ar[i] = Convert.ToInt32(Console.ReadLine());
		}
		while(true)
		{
		    Console.Clear();
		    Console.WriteLine("1. Count");
			Console.WriteLine("2. BinSearch");
			Console.WriteLine("3. Copy");
			Console.WriteLine("4. Find");
			Console.WriteLine("5. FindLast");
			Console.WriteLine("6. IndexOf");
			Console.WriteLine("7. Reverse");
			Console.WriteLine("8. Resize");
			Console.WriteLine("9. Sort");
			Console.WriteLine("10. Exit");
			
			int choise = Convert.ToInt32(Console.ReadLine());
			
			if(choise == 1)
			{
			    Console.Clear();
				Console.WriteLine($"Array lenght: {ar.Count()}");
				Console.ReadLine();
			}
			
			else if(choise == 2)
			{	
			    Console.Clear();
				Console.Write("Element: ");
				int[] cr = ar;
				int element = Convert.ToInt32(Console.ReadLine());
				Array.Sort(cr);
				Console.WriteLine(Array.BinarySearch(cr, element));
				Console.ReadLine();
			}
			else if(choise == 3)
			{
			    Console.Clear();
				int[] br = new int[2];
				Array.Copy(ar,br, 2);
				Console.WriteLine("Copied first 2 elements: ");
				foreach(int i in br){Console.Write($"{i} ");}
				Console.ReadLine();
			}
			else if(choise == 4)
			{
			    Console.Clear();
				Console.WriteLine("Finded element < 3");
				Console.Write(Array.Find(ar, element => element < 3));
				Console.ReadLine();
			}
			else if(choise == 5)
			{
			    Console.Clear();
				Console.WriteLine("Finded last element < 3");
				Console.Write(Array.FindLast(ar, element => element < 3));
				Console.ReadLine();
			}
			else if(choise == 6)
			{
			    Console.Clear();
				Console.Write("Element: ");
				int element = Convert.ToInt32(Console.ReadLine());
				Console.Write($"Index of your element is {Array.IndexOf(ar, element)}");
				Console.ReadLine();
			}
			else if(choise == 7)
			{
			    Console.Clear();
				Console.Write("Your array was reversed: ");
				Array.Reverse(ar);
				foreach(int i in ar){Console.Write($"{i} ");}
				Console.ReadLine();
			}
			else if(choise == 8)
			{
			    Console.Clear();
				Console.Write("Your array was resized: ");
				Array.Resize<Int32>(ref ar, 10);
				//foreach(int i in ar){Console.Write($"{i} ");}
				Console.WriteLine(ar.Count());
				Console.ReadLine();
			}
			else if(choise == 9)
			{
			    Console.Clear();
				Console.Write("Your array was sorted: ");
				Array.Sort(ar);
				foreach(int i in ar){Console.Write($"{i} ");}
				Console.ReadLine();
			}
			else if(choise == 10)
			{
			    Console.Clear();
				break;
			}
		}
		
	}
}
