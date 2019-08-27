using System;

namespace M5D2_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new Animal[10];
            var randomizer = new Random();
            for (int i = 0; i < animals.Length; i++)
                animals[i] = randomizer.Next(2) == 0 ? (Animal)new Fly() : (Animal)new Cat();

            Console.WriteLine(Animal.NumberOfAnimals);

            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine(i + " => ");
                animals[i].Sound();
            }

            return;


            double pi = 3.14;
            Console.WriteLine((int)pi);

            double pi2 = 3.1415;
            decimal piDecimal = (decimal)pi2;
            Console.WriteLine(piDecimal);

            //Ex3:
            //Create an array of string called Names and initialize some entry using the constructor
            var Names = new string[] { "Strive", "School", "Array", "Test" };
            string[] Names2 = { "Strive", "School", "Array", "Test" };

            //Ex4:
            //Print the names on the screen by using the foreach command
            foreach (var name in Names)
                Console.WriteLine(name);


            //Ex5:
            //Create a methods which receives a parameter N generates 10 random integer numbers between 1 and N
            RandomNumbers(12);

            //    Ex6:
            //  Create a method called Divide.The method receives two parameters, which are divided.
            //Handle the case in which the division throws an exeption by using try / catch
            Console.WriteLine(Divide(12, 30));
            Console.WriteLine(Divide(10, 0));

            //Ex7:
            //    Get an input from Console.If the input is a number, divide it by two and print the result.
            //    If not, console log the reverted string: STRIVE => EVIRTS

            HandleInput();

            //Ex8:
            //Write a program that ask for an input until the user types in the Word STRIVE(case insensitive)

            while (true)
            {
                var input =Console.ReadLine();
                if (input.ToLower() == "strive")
                    break;
            }
        }

        static void HandleInput()
        {
            var input = Console.ReadLine();
            double result;

            if (double.TryParse(input, out result)) //if input is a number
            {
                Console.WriteLine(result / 2);
            }
            else //it's a string
            {
                var output = String.Empty;
                for (int i = input.Length -1; i >= 0; i--) //reverse loop
                    output += input[i];

                Console.WriteLine(output);
            }
        }

        static double Divide(double par1, double par2)
        {
            try
            {
                return par1 / par2;
            }
            catch
            {
                return double.NaN;
            }
        }

        static void RandomNumbers(int N)
        {
            var randomNumbers = new int[10];
            var randomGenerator = new Random();
            for(int i = 0; i < 10; i++)
            {
                randomNumbers[i] = 1 + randomGenerator.Next(N);
                Console.WriteLine(randomNumbers[i]);
            }
        }
    }
}
