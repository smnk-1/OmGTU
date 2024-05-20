using System;
using System.Linq;
using System.Collections.Generic;
using Test;

namespace Test;

class Product
{
	public int id;
	public string name;
    public string category;
    public int quantity;
    public int price;
    
    public Product(int id, string name, string category, int quantity, int price)
    {
		this.id = id;
        this.name = name;
        this.category = category;
        this.quantity = quantity;
        this.price = price;
	}
}

class Warehouse
{
	public List<Product> storage = new List<Product>();
    public string name;
    
    public Warehouse(string name, List<Product> inputStorage)
    {
		this.name = name;
		storage = inputStorage;
	}
    
    public void printStorage()
    {
		foreach(Product product in storage)
        {
			Console.WriteLine($"{product.id} {product.name} {product.category} {product.quantity} {product.price}");
		}
	}
}

public static class Program
{
    public static void Main()
    {
        Warehouse warehouse_1 = new Warehouse("warehouse 1", new List<Product>(){
			new Product(1, "milk", "milk products", 25, 100),
            new Product(2, "kefir", "milk products", 39, 200),
            new Product(3, "yogurt", "milk products", 23, 50),
            new Product(4, "butter", "milk products", 43, 45),
            new Product(5, "white bread", "bakery", 10, 41),
            new Product(6, "grey bread", "bakery", 12, 29),
            new Product(7, "muffin", "bakery", 19, 15),
            new Product(8, "cucumber", "vegetables", 17, 30)
            });
        
        Warehouse warehouse_2 = new Warehouse("warehouse 2", new List<Product>(){
			new Product(1, "milk", "milk products", 35, 100),
            new Product(3, "yogurt", "milk products", 13, 50),
            new Product(4, "butter", "milk products", 33, 45),
            new Product(6, "grey bread", "bakery", 12, 29),
            new Product(7, "muffin", "bakery", 19, 15),
            new Product(9, "peach", "fruits", 20, 49)
            });
        
        List<Warehouse> warehouses = new List<Warehouse>(){warehouse_1, warehouse_2};
        
        Console.WriteLine("Query #1");
        foreach(Warehouse warehouse in warehouses)
        {
			var query_1 = from product in warehouse.storage
                select product.quantity * product.price;
                
            Console.WriteLine($"{warehouse.name} - {query_1.ToList().Sum()}");
		}
        
        Console.WriteLine("\nQuery #2");
        foreach(Warehouse warehouse in  warehouses)
        {
			Console.WriteLine($"\n{warehouse.name}");
			var query_2 = from product in warehouse.storage
                group product by product.category;
               
            foreach(var categories in query_2)
            {
                string key = categories.Key;
                
                int value = categories.Max(x => x.price);
                
                Console.WriteLine($"{key} - {value}");
            }
		}
        
        Console.WriteLine("\nQuery #3");
        foreach(Warehouse warehouse in  warehouses)
        {
			var query_3 = warehouse.storage.Select(x => x.price);

            Console.WriteLine("Average price at {0} - {1:0.##}",warehouse.name, 1.0 * query_3.Sum()/query_3.Count());
		}
        
        Console.WriteLine("\nQuery #4");
        foreach(Warehouse warehouse in  warehouses)
        {
			var query_4 = from product in warehouse.storage 
            let x = warehouse.storage.Max(x => x.price)
            where (product.price == x) 
            select product;
            
            Console.Write("\nProduct(s) with max price -");
            foreach(Product product in query_4)
            {
				Console.Write($" {product.name}");
			}
		}
        
        Console.WriteLine("\n\nQuery #5");
        int min = warehouses.Select(x => x.storage.Select(y => y.price).Sum()).ToList().Min();
        
        var query_5 = from warehouse in warehouses
                
            where (warehouse.storage.Select(x => x.price).Sum() == min)
            select warehouse;
        
        Console.WriteLine("Minimal wealth warehouse(s):");
        
        foreach(Warehouse warehouse in query_5)
        {
			Console.WriteLine($" - {warehouse.name}");
		}
    }
}
