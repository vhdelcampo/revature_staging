using System;

namespace BalanceBrackets
{
  class Program
  {
    static void Main(string[] args)
    {
      string s1 = "((()))()";
      string s2 = "()())))";
      string s3 = "(())()())";
      string s4 = "((((";
      Console.WriteLine(FixBrackets(s1));
      Console.WriteLine(FixBrackets(s2));
      Console.WriteLine(FixBrackets(s3));
      Console.WriteLine(FixBrackets(s4));
    }

    public static int FixBrackets(string s)
    {
      int RightParenCount = 0;
      int LeftParenCount = 0;
      int FixCount = 0;
      for (int i = s.Length - 1; i >= 0; i--)
      {
        if (s[i] == ')')
        {
          RightParenCount++;
          FixCount++;
        }
        else if (s[i] == '(')
        {
          LeftParenCount++;
          if (RightParenCount > 0)
          {
            FixCount--;
            RightParenCount--;
            LeftParenCount--;
          }
        }
      }
      return FixCount + LeftParenCount;
    }
  }
}
