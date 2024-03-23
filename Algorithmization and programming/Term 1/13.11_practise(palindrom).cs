// подается строка, определить наибольшую длину подстроки-палиндрома
using System;

class Program
{
    static int MaxPalindromeSubstringLength(string s)
    {
        int maxLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (IsPalindrome(s, i, j))
                {
                    int length = j - i + 1;
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }
        }
        return maxLength;
    }

    static bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
            {
                return false;
            }
            start++;
            end--;
        }
        return true;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        int result = MaxPalindromeSubstringLength(input);
        Console.WriteLine(result);
    }
}
