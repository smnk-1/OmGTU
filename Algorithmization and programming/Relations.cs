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
		Relations user_2 = new Relations("Tom", "0002", new ArrayList{"0003", "0004"});
		Relations user_3 = new Relations("N", "0003", new ArrayList{});
		Relations user_4 = new Relations("D", "0004", new ArrayList{});
	    ArrayList All = new ArrayList();
		All.Add(user_1);
		All.Add(user_2);
		All.Add(user_3);
		All.Add(user_4);
		
	    void Check_pod(Relations user)
		{
		    if(user.Podchin.Count > 0)
			{
			    foreach(string i in user.Podchin)
				{	
				    foreach(Relations us in All)
					{
					    if(us.Id == i){Console.WriteLine(i);Check_pod(us);}
					}
				}
			}
		}
		
		Check_pod(user_1);
		
	}
}
