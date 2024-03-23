using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class tovar_na_sklade
{
    private string [,] postavka = new string[4, 10];	//date postavka, date izgotov, q, cost
	private string [,] prodaja = new string [2, 10]; 	//date prodaji, q
	private string name;
	private int srok_godn;
	
	public tovar_na_sklade(string [,] post, string [,] prod, string n, int s)
	{
	    postavka  = post;
		prodaja = prod;
		name = n;
		srok_godn = s;
	}
	
}

class Program
{
    public  static int DateConvertor(string date)
    {
        string [] s = date.Split('.');
		int day = Convert.ToInt32(s[0]);
		int month = Convert.ToInt32(s[1]);
	    return 30 * (month-1) + day;
	}
	
	static void Main()
	{
	    string [,] po = {{"1.2", "20.2", "10.3"}, {"30.1", "19.2", "9.3"}, {"50", "28", "80"}, {"10", "10", "10"}};
		string [,] pr = {{"5.2", "25.2"},{"30", "40"}};
	    tovar_na_sklade pomidori = new tovar_na_sklade(po, pr, "pomidori", 7);
		
		Console.WriteLine("Date: ");
		int current_date = DateConvertor(Console.ReadLine());
		Console.WriteLine(current_date);
	}
}
