using System;
using System.Linq;
using System.Collections;

public class Cars
{
	private string ID;
    private bool Dirty;
    public Cars(string ID, bool Dirty)
    {
		this.ID = ID;
        this.Dirty = Dirty;
	}
    public bool IsDirty()
    {
		return Dirty;
	}
    public void Wash()
    {
		Dirty = false;
	}
    public string GetID()
    {
		return ID;
	}
}

public class CarWash
{
	public static void Wash(Cars car)
    {
		car.Wash();
	}
}

public static class Program
{
	public delegate void Worker(Cars car);
    
	public static void Main()
	{
		Cars car_1 = new Cars("1", false);
        Cars car_2 = new Cars("2", true);
		Cars[] Garage = [car_1, car_2];
        
        Worker wash = CarWash.Wash;
        
        foreach(Cars car in Garage)
        {
			if(car.IsDirty() == true)
            {
				wash(car);
                if(car.IsDirty() == false){Console.WriteLine($"Car {car.GetID()} is washed");}
			}
		}
    }
}
