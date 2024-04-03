using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhoneNubmersTask2;


//2) На вход подаются данные: номера телефона звонителя, номер звонимого, дата разговора, кол-во минут
//    а) Определить, на какой номер чаще всего звонил выбранный абонент, сгруппировав данные по датам
//
//    б) Определить номера, с которыми наибольшее количество минут разговаривал каждый абонент, сгруппировав данные по дате

namespace PhoneNubmersTask2
{
    class Abonent
    {
        public string number;
        public List<Date> calldata = new List<Date>();

        public Abonent(string number)
        {
            this.number = number;
        }

        public void AddCall(string number2, string date)
        {    
			bool check = false;
            foreach (Date d in calldata)
            {
                if(d.date == date) { d.AddCall(number2); check = true;}
            }
            if(check == false)
            {
                Date new_d = new Date(date);
                new_d.AddCall(number2);
                calldata.Add(new_d);
            }
    
        }
        
        public void MostFrequent()
        {
			foreach(Date data in calldata)
            {
				int maxvalue = data.calls.Values.Max();
                foreach(string k in data.calls.Keys)
                {
					if(data.calls[k] == maxvalue)
                    {
						Console.WriteLine($"{data.date}: {k}");
					}
				}
			}
		}
    }

    class Date
    {
        public string date;
        public Dictionary<string, int> calls = new Dictionary<string, int>();
        public Date(string date)
        {
            this.date = date;
        }
        public void AddCall(string number_call_to)
        {
            if(calls.ContainsKey(number_call_to))
            {
                calls[number_call_to] += 1;
            }
            else 
            {
                calls.Add(number_call_to, 1);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Abonent> abonents = new List<Abonent>();
            
            Console.WriteLine("Writer number_from number_to date(dd.mm.yyyy) duration OR END");
            while(true)
            {    
				string[] inputs = Console.ReadLine().Split(' ');
                if(inputs.Length != 4 && inputs[0] != "END") { Console.WriteLine("Input error"); }
                else if(inputs[0] == "END"){break;}
                else
                {    
				    string number_from = inputs[0];
                    string number_to = inputs[1];
                    string call_date = inputs[2];
                    string call_duration = inputs[3];
                    bool flag = false;
                    
                    foreach(Abonent user in abonents)
                    {    
					    if(user.number == number_from)
                        {
						    user.AddCall(number_to, call_date);
                            flag = true;
                            break;
					    }
				    }
                    if(flag == false)
                    {
					    Abonent new_abonent = new Abonent(number_from);
					    abonents.Add(new_abonent);
                        new_abonent.AddCall(number_to, call_date);
                    }
                }
			}
            Console.Write("Needed number: ");
            string needed_number = Console.ReadLine();
            foreach(Abonent user in abonents)
            {
				if(user.number == needed_number)
                {
					user.MostFrequent();
				}
			}
            
        }
        
    }
}
