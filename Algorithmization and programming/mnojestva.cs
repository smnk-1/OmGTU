// 1) персечение всех множеств
// 2) объединиение всех множеств
// 3) дополнение для каждого относительно объединения

using System; 
using System.Linq; 
using System.Collections.Generic;

 
class Program
{  
 static void Main()
 {
  Console.Write("Введите кол-во строк: ");
  int N = Convert.ToInt32(Console.ReadLine());
  int K = 0;
  
  int [][] arr = new int [N][]; 
  for(int i = 0; i < N; i ++)
  {
   Console.Write(($"Длина строки {i+1}: "));
   int m = Convert.ToInt32(Console.ReadLine());
   arr[i] = new int[m];
   Console.WriteLine($"Вводите элементы строки {i+1}:");
   for (int j = 0; j < m; j ++)
   {
    arr[i][j] = Convert.ToInt32(Console.ReadLine());
   }
  }
  
  Console.WriteLine(" ");
  foreach(int[] s in arr)
  {
   foreach(int str in  s)
   {
    Console.Write(str + " ");
    K += 1;
   }
   Console.WriteLine(" ");
  }
  
  //1
  int [] answ_1 = new int[K];
  int element = 0;
  Console.WriteLine(" ");
  Console.WriteLine("1) Объединение:");
  
  for(int i = 0; i < N; i ++)
  {
   for(int j = 0; j < arr[i].Length; j ++)
   {
    if (answ_1.Contains(arr[i][j]))
    {
     answ_1[element] = int.MinValue;
    }
    else
    {
     answ_1[element] = arr[i][j];
    }
    element += 1;
   }
  }
  
  for (int i = 0; i < answ_1.Length; i ++)
  {
   if(answ_1[i] > int.MinValue)
   {
    Console.Write(answ_1[i] + " ");
   }
  }
  
  //2
  Console.WriteLine("\n");
  Console.WriteLine("2) Пересечение");
  int [] answ_2 = new int[K];
  element = 0;
  int check = 1;
  
  for(int i = 0; i < N; i ++)
  {
   for(int j = 0; j < arr[i].Length; j ++)
   {
    check = 1;
    for(int q = 0; q < N; q ++)
    {
     if(arr[q].Contains(arr[i][j]) == false )
     {
      check *= 0;
     }
    }
    if(check==1 && answ_2.Contains(arr[i][j])==false)
    {
     answ_2[element] = arr[i][j];
    }
    else{answ_2[element] = int.MinValue;}
    element += 1;
    
   }
  }
  
  for (int i = 0; i < answ_2.Length; i ++)
  {
   if(answ_2[i] > int.MinValue)
   {
    Console.Write(answ_2[i] + " ");
   }
  }
  
  //3
  Console.WriteLine("\n");
  Console.WriteLine("3) Дополнение");
  
  for(int i = 0; i < N; i ++)
  {
   for(int j = 0; j < K; j ++)
   {
    if(arr[i].Contains(answ_1[j]) == false && answ_1[j] != int.MinValue){Console.Write(answ_1[j]+" ");}
   }
   Console.WriteLine(" ");
  }
 }
}