using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter set A: ");
            string[] setA  = Console.ReadLine().Split();

            Console.Write("Enter set B: ");
            string[] setB = Console.ReadLine().Split();

            Console.Write("Enter set C: ");
            string[] setC = Console.ReadLine().Split();

            IEnumerable<string> AandB = from word in setA.Intersect(setB) select word;
            Console.Write("A and B: ");
            foreach (string s in AandB) {Console.Write(s + ' '); }
            Console.WriteLine(' ');

            IEnumerable<string> AorC = from word in setA.Union(setC) select word;
            Console.Write("A or C: ");
            foreach (string s in AorC) { Console.Write(s + ' '); }
            Console.WriteLine(' ');

            IEnumerable<string> All = from word in AorC.Union(setB) select word;
            Console.Write("U: ");
            foreach (string s in All) { Console.Write(s + ' '); }
            Console.WriteLine(' ');

            IEnumerable<string> NotA = from word in All.Except(setA) select word;
            Console.Write("Addition of A to U: ");
            foreach (string s in NotA) { Console.Write(s + ' '); }
            Console.WriteLine(' ');

            IEnumerable<string> NotB = from word in All.Except(setB) select word;
            Console.Write("Addition of B to U: ");
            foreach (string s in NotB) { Console.Write(s + ' '); }
            Console.WriteLine(' ');

            IEnumerable<string> NotC = from word in All.Except(setC) select word;
            Console.Write("Addition of C to U: ");
            foreach (string s in NotC) { Console.Write(s + ' '); }
            Console.WriteLine(' ');
        }
    }
}
