using System;
using System.Collections.Generic;
using System.Text;

namespace M5D2_Exercises
{
    class Fly : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Bzzzzz");
        }

        public Fly() : base(6,2)
        {

        }
    }
}
