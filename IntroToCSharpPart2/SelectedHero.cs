using IntroToCSharpPart2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2
{
    class SelectedHero
    {
        private static Hero _instance { get; set; }

        public static Hero Instance
        {
            get
            {
                if (_instance == null)
                {
                    switch (SpecifiedClass)
                    {
                        case "mage": _instance = new Mage();  break;
                        case "warrior": _instance = new Warrior("whatever"); break;
                        default: throw new Exception("You should specify the SpecifiedClass first");
                    }
                }
                return _instance;
            }
        }

        public static string SpecifiedClass { get; set; }

        
    }
}
