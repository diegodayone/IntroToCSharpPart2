using IntroToCSharpPart2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2
{
    class SingleTonSomething
    {
        private static Hero _arena;

        public static Hero Instance
        {
            get
            {
                if (_arena == null)
                    _arena = new Mage();

                return _arena;
            }
        }
    }
}
