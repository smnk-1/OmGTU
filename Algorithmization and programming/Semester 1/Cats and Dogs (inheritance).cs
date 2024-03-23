using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Animals
{	
    public string name;
	public int birth_year;
	
	public Animals(string n, int y)
	{
	    name = n;
		birth_year = y;
	}
	
}
class Cats: Animals
{
    private string type;
    private string color;
    public Cats(string n, int y, string t, string c)
	    : base(n, y)
	{	
		type = t;
		color = c;
	}
	public void SearchByColor(string c)
	{
	    if(color==c){Console.WriteLine(name);}
	}
	public void ChangeType(string new_type)
	{
	    Console.Write($"{type} => ");
		type = new_type;
		Console.WriteLine($"{type}");
	}
}
class Dogs: Animals
{
    private string type;
    private string color;
    public Dogs(string n, int y, string t, string c)
	    : base(n, y)
	{	
		type = t;
		color = c;
	}
	public void SearchByType(string t)
	{
	    if(type==t){Console.WriteLine(name);}
	}
}
           

class Program
{	
	static void Main()
	{
	   Cats Bonny = new Cats("Bonny", 2020, "None", "White");
	   Cats Binny = new Cats("Binny", 2022, "Manckin", "Grey");
	   Cats Beky = new Cats("Beky", 2015, "Bald", "None");
	   Cats[] array_cats = {Bonny, Binny, Beky};
	   Console.Write("Search cats for color: ");
	   string searching_color = Console.ReadLine();
	   for(int i = 0; i < array_cats.Length; i ++){array_cats[i].SearchByColor(searching_color);}
	   
	   Dogs Max = new Dogs("Max", 2016, "Labrador", "Brown");
	   Dogs Rex = new Dogs("Rex", 2019, "Labrador", "White");
	   Dogs[] array_dogs = {Max, Rex};
	   Console.Write("Search dogs by type: ");
	   string searching_type = Console.ReadLine();
	   for(int i = 0; i < array_dogs.Length; i ++){array_dogs[i].SearchByType(searching_type);}
	   Console.Write("New type: ");
	   string new_type = Console.ReadLine();
	   Beky.ChangeType(new_type);
	}
}
