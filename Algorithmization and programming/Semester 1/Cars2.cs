using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Car
{
	private string carName;
	private int carFactoryYear;
	private string[] carUsers = new string[10];
	private int[] carCheck = new int[10];
	private string carColor;
	private int carID;

	public Car(string Name, int FactoryYear, string[] Users, int[] Check, string Color, int ID)
	{
		carName = Name;
		carFactoryYear = FactoryYear;
		if(Users.Length <= 10){carUsers = Users;} 
		else{carUsers = ["Overflow"];}
		if(Check.Length <= 10){carCheck = Check;} 
		else{carCheck = [0];}
		carColor = Color;
		carID = ID;
	}

	public void Print()
	{
		Console.WriteLine($"{carName}");
		Console.WriteLine($"{carFactoryYear}");
		for(int i = 0; i < carUsers.Length; i ++){Console.WriteLine($"{carUsers[i]}");}
		for(int i = 0; i < carCheck.Length; i ++){Console.WriteLine($"{carCheck[i]}");}
		Console.WriteLine($"{carColor}");
	}
	
	public void SearchByID(int ID)
	{
	    if (ID == carID)
		{
		Print();
		}
	}
	
	public void SearchOneUser(int Users)
	{
	    if(carUsers.Length == Users){Console.WriteLine($"{carID}");}
	}
	
	public void SearchByYear(int Year)
	{
	    if(carCheck.Contains(Year) == true){Console.WriteLine($"{carID}");}
	}
}


class Program
{
	static void Main()
	{
		Car car1 = new Car("Lada Granta", 2019, ["Vova", "Victor", "Artem"], [2019, 2020], "Blue", 123);
		Car car2 = new Car("Toyota", 1991, ["Alphred"], [1992, 1993, 1994, 1995, 2008, 2020], "Pink", 183745);
		Car car3 = new Car("Chevrolet", 2005, ["Tom", "Jhon", "Nick"], [2005, 2007], "Black", 23085983);
		Car[] cars = [car1, car2, car3];
		
		Console.Write("Enter ID: ");
		int searchingID = Convert.ToInt32(Console.ReadLine());
		for(int i = 0; i < cars.Length; i ++){cars[i].SearchByID(searchingID);}
		
		Console.Write("Enter Users: ");
		int searchingUsers = Convert.ToInt32(Console.ReadLine());
		for(int i = 0; i < cars.Length; i ++){cars[i].SearchOneUser(searchingUsers);}
		
		Console.Write("Enter Year: ");
		int searchingYear = Convert.ToInt32(Console.ReadLine());
		for(int i = 0; i < cars.Length; i ++){cars[i].SearchByYear(searchingYear);}
	}
}
