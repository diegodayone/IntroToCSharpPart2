using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    static class MyStringComparer
    {
        public static bool CompareString(string s1, string s2)
        {
            return String.Equals(s1, s2);
        }
    }


    abstract class ICannotBeInstantiated
    { 
        public bool CompareString(string s1, string s2)
        {
            return String.Equals(s1, s2);
        }

        public abstract void ICanBePressed();
    }

    class ICanBeInstantiated : ICannotBeInstantiated
    {
        public override void ICanBePressed()
        {
            Console.WriteLine("I've been pressed");
        }
    }
}
