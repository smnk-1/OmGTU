using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

class Program
{
	static void Main()
	{	
		Dictionary<char, char> pairs = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { ')', '(' } };
		string equation = " ')'";
		bool flag = true;
		Stack<char> skobki = new Stack<char>();
		foreach (char s in equation)
		{
			if (s == '{' || s == '[' || s == '(')
			{
				skobki.Push(s);
			}
			else if (s == ')' || s == ']' || s == '}')
			{
				if (skobki.Count() == 0)
				{
					flag = false;
					break;
				}
				if (skobki.Peek() == pairs[s] && skobki.Count()!= 0) { skobki.Pop(); }
				else
				{
					flag = false;
					break;
				}
			}
		}
		if (flag && skobki.Count() == 0) { Console.WriteLine("Ok"); }
		else{Console.WriteLine("Error");}
	}
}
