using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public struct new1
    {
        public string name { get; set; }
    }

    public static class IntExtension
    {
        public static bool greaterthan(this int i, int value)
            {
            return i > value;
          }

        public static string reversing(this string str1)
        {
            int n = str1.Length;
            string str2 = "";
            for(int i =n-1; i >= 0; i--)
            {
                str2 += str1[i];
            }
            return str2;
        }
    }

   
}
