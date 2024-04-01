using System;
using System.Linq;

interface IOperations
{
	double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
    double SquareRoot(double a);
    double Sin(double a);
    double Cos(double a);    
}

class MathOperations: IOperations
{
	public double Add(double a, double b)
    {
		return a + b;
	}
    public double Subtract(double a, double b)
    {
		return a - b;
	}
    public double Multiply(double a, double b)
    {
		return a * b;
	}
    public double Divide(double a, double b)
    {
		return a/b;
	}
    public double SquareRoot(double a)
    {
		return Math.Sqrt(a);
	}
    public double Sin(double a)
    {
		return Math.Sin(a);
	}
    public double Cos(double a)
    {
		return Math.Cos(a);
	}
}

public static class Program
{
	public delegate double UnarOperation(double x);
    public delegate double BinarOperation(double x, double y);
    
	public static void Main()
	{
		MathOperations obj = new MathOperations();
        BinarOperation bin_operation = new BinarOperation(obj.Add);
        UnarOperation unar_operation = new UnarOperation(obj.Sin);
        
		Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. SquareRoot");
        Console.WriteLine("6. Sin");
        Console.WriteLine("7. Cos");
        
		string x = Console.ReadLine();
        Console.Clear();

        if(x == "1")
        {    
            bin_operation = new BinarOperation(obj.Add);
		}
        else if(x == "2")
        {
			bin_operation = new BinarOperation(obj.Subtract);
		}
        else if(x == "3")
        {
			bin_operation = new BinarOperation(obj.Multiply);
		}
        else if(x == "4")
        {
			bin_operation = new BinarOperation(obj.Divide);
		}
        else if(x == "5")
        {
			unar_operation = new UnarOperation(obj.SquareRoot);
		}
        else if(x == "6")
        {
			unar_operation = new UnarOperation(obj.Sin);
		}
        else if(x == "7")
        {
			unar_operation = new UnarOperation(obj.Cos);
		}
        
        if(x == "1"|| x == "2"||x == "3" || x == "4")
        {
			Console.Write("a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            if(x == "4" && b == 0)
            {
			    Console.WriteLine("Division by zero");
		    }
            else
            {
					Console.WriteLine(bin_operation(a, b));
			}
		}
        else if(x == "5"|| x == "6"||x == "7")
        {
			double a = Convert.ToDouble(Console.ReadLine());
			if (x == "5" && a < 0)
            {
			    Console.WriteLine("Square error");
		    }
            else{Console.WriteLine(unar_operation(a));}
		}        
    }
}
