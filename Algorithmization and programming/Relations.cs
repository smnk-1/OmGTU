using System;
using System.Linq;
using System.Collections.Generic;
using CSharpShellCore;
using System.Collections;

class Relations
{
    public string Name;
	public string Id;
	public ArrayList Podchin = new ArrayList();    
	
	public Relations(string n, string id, ArrayList pod)
	{
	    Name = n;
		Id = id;
		if(pod.Count > 0)
		{
		    foreach(string i in pod){Podchin.Add(i);}
		}
	}
}

class Program
{
	static void Main()
	{	
	    Relations user_1 = new Relations("Mark", "0001", new ArrayList {"0002"});
		Relations user_2 = new Relations("Tom", "0002", new ArrayList{});
	    ArrayList All = new ArrayList();
		All.Add(user_1);
		All.Add(user_2);
		
	    void Check_pod(Relations user)
		{
		    if(user.Podchin.Count > 0)
			{
			    foreach(string i in user.Podchin)
				{	
				    Console.WriteLine(i.Id);
					Check_pod(i);
				}
			}
		}
		
		Check_pod(user_1);
		
	}
}
