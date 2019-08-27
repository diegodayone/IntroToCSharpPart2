using System;
using System.Collections.Generic;
using System.Text;

namespace M5D2_Exercises
{
    class Cat : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Meow");
        }

        public Cat() : base(4,0)
        {

        }
    }
}
