using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    //SUPER CLASS, PARENT, BASE CLASS
    abstract class Hero : ILivingThing 
    {
        #region Properties
        public string Name;
        public int MaximumHealthPoint;
        public int CurrentHealthPoint;

        public int MaximumManaPoint;
        public int CurrentManaPoint;

        public int Range;

        public static int HeroesCreated;
        public DateTime HeroCreationDate;
        #endregion

        #region Constructor
        public Hero(string name)
        {
            Name = name;
            HeroesCreated++;
            HeroCreationDate = DateTime.Now;
        }
        #endregion

        #region BasicAttacks

        private void UpdateMana(int manaDifference)
        {
            this.CurrentManaPoint += manaDifference;
        }

        //if you want a method to be overridable, it should be virtual or abstract
        public virtual void Attack(ILivingThing enemy)
        {
            Console.WriteLine(Name + " is attacking " + enemy.ToString());
        }

        public abstract void SpecialAttack();
        #endregion


        public override string ToString()
        {
            return Name + "HP(" + CurrentHealthPoint + "/" + MaximumHealthPoint + ")" + " MP(" + CurrentManaPoint + "/" + MaximumManaPoint + ")";
        }

        public void QuitGame()
        {
            //string myString = null;
            //myString.ToUpper();

            var myArray = new string[2];
            
            for(int i = 0; i <= 2; i++)
            {
                //0
                //1
                //2 -> EXPLODE!!!
                Console.WriteLine(myArray[i]);
            }

        }


        public void PrintSomething()
        {
            Console.Write("Something" + Name + CurrentHealthPoint + " => " + HeroesCreated);
        }

        /*
         * [Hero1 Mage] Galdalf 10 HP
         * [Hero2 Warrior] Hercules 20 HP
         * 
         * Hero => 2 heroes has been created.
         * 
         * Hero.Name => Ok, but which name? I mean, you are a blueprint, you don't have a name!
         * Hero1.Name => Ok, my name is Gandalf
         * Hero1.CurrentHeroesNumber => Go to the parent class, and take the information, So, 2, man!
         * 
         * */

        public static void PrintSomething2()
        {
            Console.Write("Something" + HeroesCreated);
        }

        //function CalculateMoonDistance()
        //{
        //    return 12 * 1000000;
        //}

        //public double CalculateMoonDistance()
        //{
        //    return 12 * 1000000;
        //}
        //private void PrintMyName()
        //{
        //    Console.WriteLine("Diego");
        //}
    }
}
