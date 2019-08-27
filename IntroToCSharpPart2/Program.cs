using System;
using IntroToCSharpPart2.Models;

namespace IntroToCSharpPart2
{
    class Program
    {
        //static Hero myHero;
        static void Main(string[] args)
        {
            try
            {
                //Open File
                //Read File

                new Hero("whatever").QuitGame();
            }
            catch (NullReferenceException nullReference)
            {
                Console.WriteLine("this code is executed ONLY if a NULL REFERENCE exeption occurs");
                Console.WriteLine(nullReference.Message + nullReference.StackTrace);
            }
            catch (IndexOutOfRangeException indexOutOfRange)
            {
                Console.WriteLine("this code is executed ONLY if a indexOutOfRange exeption occurs");
                Console.WriteLine(indexOutOfRange.Message + indexOutOfRange.StackTrace);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + exception.StackTrace);
            }
            finally
            {
                //Close File
                Console.WriteLine("this code is executed in any case");
            }

            Console.WriteLine("Welcome to Strive RPG");
            Console.WriteLine("Select your name!");

            var selectedName = Console.ReadLine();

            Hero selectedHero = null;

            while (selectedHero == null)
            {
                Console.WriteLine("Select your class!");
                var selectedClass = Console.ReadLine();
                switch (selectedClass.ToLower())
                {
                    case "warrior":
                        selectedHero = new Warrior(selectedName);
                        break;
                    case "mage":
                        selectedHero = new Mage();
                        break;
                    case "bard":
                        selectedHero = new Bard(selectedName);
                        break;
                    default:
                        Console.WriteLine("Select a valid class");
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("Perform your attack! 1 for special attack, 2 for normal attack");
                Console.WriteLine(selectedHero.ToString());
                var selectedAttack = Console.Read();
                var number = Convert.ToChar(selectedAttack);

                if (number == '1')
                {
                    selectedHero.Attack();
                }
                else if (number == '2')
                {
                    selectedHero.SpecialAttack();
                }
                else
                {
                    Console.WriteLine("Thanks for playing with us");
                    break;
                }
            }


            //select your warrior
            //Hero selectedHero = new Mage();
            //selectedHero.SpecialAttack();
            //selectedHero.Attack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();

            //selectedHero = new Warrior("Hercules");
            //selectedHero.SpecialAttack();
            //selectedHero.Attack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();

            //var xena = new Warrior("Xena");


            //if (selectedHero.GetType() == typeof(Warrior))
            //{
            //    Console.WriteLine("The warrior is attacking");
            //    //....
            //}
            //else if (selectedHero.GetType() == typeof(Mage))
            //{
            //    Console.WriteLine("The mage is attacking");
            //    //..
            //}
            //else if (selectedHero.GetType() == typeof(Rogue))
            //{
            //    Console.WriteLine("The rogue is attacking");
            //    //..
            //}
            //else if (selectedHero.GetType() == typeof(Necromancer))
            //{
            //    Console.WriteLine("The necro is attacking");
            //    //..
            //}
            return;
            var names = System.IO.File.ReadAllLines("Names.txt");
            foreach(var name in names )
            {
                Console.WriteLine(name);
            }

            int x = 12;

            var myIntegerArray = new[] { 2, 3, 4, 45 };

            for (var i = 0; i < myIntegerArray.Length; i++)
            {
                Console.WriteLine(myIntegerArray[i]);
            }

            foreach(var whatever in myIntegerArray)
            {
                Console.WriteLine(whatever);
            }

            var myArray = new int[10];

            for(var i = 0; i < 10; i++)
            {
                myArray[i] = i;
            }

            //var myArrayWithTwoItems = new string[2];
            //myArrayWithTwoItems[0] = "Strive";
            //myArrayWithTwoItems[1] = "School";
            //var secondArray = new string[] { "Strive", "School" };
            //string[] thirdArray = { "Strive", "School" };
            //var forthArray = new[] { "Strive", "School" };

            /*
             * array1 = [ 0 , 23 , 25 , 20 ] 
             * array[3] =----------^
             * hey, add me an item at the end of the array!
             * 
             * -- find in memory some 5 space to use
             * -- clone the array into this 5 space area
             * -- put in the last the value that you select
             * array1 = [ 0 , 23 , 25 , 20, NewValue ] 
             * 
             * list = [ 0 ---> 2 ---> 25 --> 20 ]
             * 
             * ---------^
             *         item3?
             *         ------->
             *                item3?
             *                -------->
             *                
             * Where is item 3? Search the item is slower
             * 
             * list = [ 0 ---> 2 ---> 25 --> 20 --> newItem ]
             * 
             * */
        }
    }
}
