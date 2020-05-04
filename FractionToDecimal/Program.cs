// Coding Challenge: Given a numerator and a denominator, find what the equivalent decimal representation is as a string. 
// If the decimal representation has recurring digits, then put those digits in brackets (ie 4/3 should be represented by 1.(3) to represent 1.333...). 
// Do not use any built in evaluator functions. You can also assume that the denominator will be nonzero

using System;
using System.Collections.Generic;
using System.Text;

namespace FractionToDecimal
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(ToDecimalString(5, 3));
    }
    public static string ToDecimalString(int n, int d)
    {
      double dec = (double)n / d;
      StringBuilder sb = new StringBuilder();
      if (!HasRepeatingDecimals(d) || n % d == 0)
      {
        sb.Append(dec);
      }
      else
      {
        String s = sb.Append(dec).ToString();
        int index = s.IndexOf('.');
        sb.Clear();
        char repeat = ' ';
        for (int i = index + 1; i < s.Length; i++)
        {
          if (s[i] == s[i - 1])
          {
            repeat = s[i];
            break;
          }
        }
        sb.Append(s.Substring(0, index));
        sb.Append(".");
        sb.Append("(" + repeat + ")");
      }
      return sb.ToString();
    }
    public static int GCD(int n1, int n2)
    {
      while (n2 > 0)
      {
        int r = n1 % n2;
        n1 = n2;
        n2 = r;
      }
      return n1;
    }
    public static Boolean HasRepeatingDecimals(int n)
    {
      List<int> p = PrimeFactorization(n);
      foreach (var item in p)
      {
        if (item != 5 || item != 2) { return false; }
      }
      return true;
    }
    public static List<int> PrimeFactorization(int n)
    {
      var primes = new List<int>();
      for (int div = 2; div <= n / 2; div++)
      {
        while (n % div == 0)
        {
          primes.Add(div);
          n /= div;
        }
      }
      return primes;
    }
  }
}