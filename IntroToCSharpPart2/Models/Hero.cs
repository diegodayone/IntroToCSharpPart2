using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    //SUPER CLASS, PARENT, BASE CLASS
    class Hero
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

        //if you want a method to be overridable, it should be virtual or abstract
        public virtual void Attack()
        {
            Console.WriteLine(Name + " is attacking!");
        }

        public virtual void SpecialAttack()
        {
            Console.WriteLine(Name + " is using his special attack");
        }
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
    }
}
