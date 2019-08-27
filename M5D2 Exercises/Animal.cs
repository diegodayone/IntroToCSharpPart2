using System;
using System.Collections.Generic;
using System.Text;

namespace M5D2_Exercises
{
    class Animal
    {
        int NumberOfLegs;
        int NumberOfWings;
        string Name;
        string Category;
        public static int NumberOfAnimals = 0;

        public Animal(int numberOfLegs = 0, int numberOfWings = 0)
        {
            NumberOfLegs = numberOfLegs;
            NumberOfWings = numberOfWings;
            NumberOfAnimals++;
        }

        public virtual void Sound()
        {
            Console.WriteLine("This is my generic sound");
        }

        public override string ToString()
        {
            return Category + " - " + Name + "( " + NumberOfLegs + " / " + NumberOfWings + ")";
        }
    }
}
