using System;
using System.Collections.Generic;
using System.Linq;


namespace RGR
{
    public class Brackets
    {
        private static Dictionary<char, char> pairs = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { ')', '(' } };
        static bool flag = true;
        static Stack<char> skobki = new Stack<char>();
		
        public static bool CheckBrackets(string equation)
        {

            foreach (char s in equation)
            {
                if (s == '{' || s == '[' || s == '(')
                {
                    skobki.Push(s);
                }
                else if (s == ')' || s == ']' || s == '}')
                {
                    if (skobki.Count() == 0)
                    {
                        flag = false;
                        break;
                    }
                    if (skobki.Peek() == pairs[s] && skobki.Count() != 0) { skobki.Pop(); }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag && skobki.Count() == 0) { return true; }
            else { return false; }
        }
	}

    public class PolishNotation
    {
        static private string[] operations = new string[] { "+", "-", "*", "/" };
        static private Stack<double> stack = new Stack<double>();
        static private bool valid = true;

        public static bool CheckNotation(string str)
        {
            var notation = str.Split();
            foreach (string elem in notation)
            {
                bool isDouble = double.TryParse(elem, out double number);
                if (isDouble)
                {
                    stack.Push(number);
                }
                else if (Array.IndexOf(operations, elem) != -1)
                {
                    if (stack.Count < 2)
                    {
                        valid = false;
                        break;
                    }
                    double n1 = stack.Pop();
                    double n2 = stack.Pop();
                    if (elem == "+")
                    {
                        stack.Push(n2 + n1);
                    }
                    else if (elem == "-")
                    {
                        stack.Push(n2 - n1);
                    }
                    else if (elem == "*")
                    {
                        stack.Push(n2 * n1);
                    }
                    else if (elem == "/")
                    {
                        if (n1 == 0)
                        {
                            valid = false;
                        }
                        else
                        {
                            stack.Push(n2 / n1);
                        }
                    }
                }
            }
            if (stack.Count != 1)
            {
                valid = false;
            }
            return valid;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            bool IsInt(string try_int)
            {
                bool check_n = true;
                foreach (char value in try_int)
                {
                    if (char.IsDigit(value) == false) { check_n = false; break; }
                }
                return check_n;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Author information");
                Console.WriteLine("2. Check Polish Notation");
                Console.WriteLine("3. Check Brakets");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();
                if(input != "")
                    if (IsInt(input))
                    {
                        switch(Convert.ToInt32(input))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Author:" + '\t' + "Semikin Nikolay");
                                Console.WriteLine("Group:" + '\t' + "FIT 232");
                                Console.WriteLine("Press Enter to contionue");
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("Write Polish Notaion: ");
                                string notation = Console.ReadLine();
                                Console.WriteLine($"Polish notation is {PolishNotation.CheckNotation(notation)}");
                                Console.WriteLine("Press Enter to contionue");
                                Console.ReadLine();
                                break;
                            case 3:
                                Console.Clear();
                                Console.Write("Write Brackets: ");
                                string brackets = Console.ReadLine();
                                Console.WriteLine($"Brackets are {Brackets.CheckBrackets(brackets)}");
                                Console.WriteLine("Press Enter to contionue");
                                Console.ReadLine();
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;

                        }
                    }
            }
        }
    }
}
