using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;

class Student
{
	public string empName{get; set;}
	public int empYear{get; set;}
	public string empGroup{get; set;}
	
	public Student(string Name, int Year, string Group)
	{
		empName = Name;
		empYear = Year;
		empGroup = Group;
	}
	
	public string GetName()
	{
		return empName;
	}
	
	public void SearchByYear(int year)
	{
		if(year == empYear){Console.WriteLine($"{empName}, {empYear}, {empGroup}");}
	}
	
	public void SearchByGroup(string group)
	{
		if(group == empGroup){Console.WriteLine($"{empName}, {empYear}, {empGroup}");}
	}
}


class Program
{		
	static void Main()
	{
		// creating the array of exemplars of class
		Student[] students = new Student[4] {new Student("Bob", 2000, "Fit"), new Student("John", 1991, "Fit"), new Student("Ryan", 1980, "Gooseling"), new Student("Vadim", 2005, "Fit")};
		
		Console.Write("Year: ");
		int SearchingYear = Convert.ToInt32(Console.ReadLine());
		for(int i = 0; i<students.Length; i ++){students[i].SearchByYear(SearchingYear);}
		
		Console.Write("Group: ");
		string SearchingGroup = Console.ReadLine();
		for(int i = 0; i<students.Length;  i++){students[i].SearchByGroup(SearchingGroup);}
	}
}
