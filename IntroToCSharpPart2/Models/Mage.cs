using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    //CHILD CLASS
    class Mage : Hero
    {
        #region Properties
        public int NumberOfSpells = 1;
        #endregion


        #region Constructor
        public Mage() : base("Gandalf")
        {
            this.CurrentHealthPoint = 10;
            this.CurrentManaPoint = 15;
            this.MaximumHealthPoint = 10;
            this.MaximumManaPoint = 15;
            this.Range = 5;
        }
        #endregion

        public void Explode()
        {
            Console.WriteLine("BOOOM");
        }

        #region Attacks


        public override void SpecialAttack()
        {
            if (this.CurrentManaPoint >= 5)
            {
                this.CurrentManaPoint -= 5;
                NumberOfSpells++;
                Console.WriteLine(Name + " using the fireball!");
            }
            else
            {
                Console.WriteLine("You don't have enough Mana point to throw a fireball");
            }
        }
        #endregion
    }
}
