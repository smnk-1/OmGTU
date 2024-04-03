
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


//2) На вход подаются данные: номера телефона звонителя, номер звонимого, дата разговора, кол-во минут
//    а) Определить, на какой номер чаще всего звонил выбранный абонент, сгруппировав данные по датам
//
//    б) Определить номера, с которыми наибольшее количество минут разговаривал каждый абонент, сгруппировав данные по дате

namespace PhoneNubmersTask2
{
    class Abonent
    {
        public string number;
        public List<Date> calldata;

        public Abonent(string number)
        {
            this.number = number;
        }

        public void AddCall(string number, string date)
        {
            bool chech = false;
            foreach (Date d in calldata)
            {
                if(d.date == date) { d.AddCall(number); chech = true}
            }
            if(chech == false)
            {
                Date new_d = new Date(date);
                new_d.AddCall(number);
                calldata.Add(new_d);
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
        public void AddCall(string number)
        {
            if(calls.ContainsKey(number))
            {
                calls[number] += 1;
            }
            else 
            {
                calls.Add(number, 1);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Abonent> abonents;

            string[] input = Console.ReadLine().Split(' ');
            if(input.Length != 4) { Console.WriteLine("Input error"); }
            else
            {

            }
        }
        
    }
}
