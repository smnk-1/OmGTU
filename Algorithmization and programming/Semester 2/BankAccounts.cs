using System;
using System.Linq;
using System.Collections.Generic;
using Test;

namespace Test;

class Account
{
	public int ID;
	public string name;
    public int income;
    public int expenses;
    public double tax;
    
    public Account(int ID, string name, int income, int expenses)
    {
		this.ID = ID;
        this.name = name;
        this.income = income;
        this.expenses = expenses;
        tax = income*0.05;
	}  
}

public static class Program
{
    public static void Main()
    {
        List<Account> Accounts = new List<Account>(){
		    new Account(1, "Ivanov Ivan Ivanich", 86000, 50000),
            new Account(2, "Fedorov Robert Alfredovich", 67000, 45000),
            new Account(3, "Teterin Vasiliy None", 100000, 100000),
            new Account(4, "Krendele'v Konstantin Ivanovich", 60000, 59000)
		};
        
        Console.WriteLine("Accounts with a negative balance:");
        
        var query = from account in Accounts 
            where (account.income - account.expenses - account.tax < 0) 
            select account;
        
        foreach(Account account in query)
        {
			Console.WriteLine($" - {account.name}");
		}
        Console.WriteLine();
        
        var query2 = from account in Accounts 
            where (account.income - account.expenses - account.tax > 0) 
            select account;
        
        Console.WriteLine($"Number of accounts with a positive balance : {query2.Count()} \n");
        
        //Account item = Accounts.MaxBy(x => x.income);
        
        var query3 = from account in Accounts 
            let x = Accounts.Max(x => x.income)
            where (account.income == x) 
            select account;
        
        Console.WriteLine("Accounts with a maximum balance:");
        
        foreach(Account account in query3)
        {
			Console.WriteLine($" - {account.name}");
        }
        Console.WriteLine();
        
        double total_taxes = Accounts.Select(x => x.tax).ToList().Sum();
        Console.WriteLine($"Total tax: {total_taxes}");
    }
}
