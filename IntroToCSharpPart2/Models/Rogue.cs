using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    //CHILD CLASS, EXTENDS the base class Hero
    class Rogue : Hero
    {
        public Rogue(string foo) : base(foo)
        {
            this.CurrentHealthPoint = 20;
            this.CurrentManaPoint = 5;
            this.MaximumHealthPoint = 20;
            this.MaximumManaPoint = 5;
            this.Range = 1;
        }

     

        public override void SpecialAttack()
        {
            if (this.CurrentManaPoint >= 3)
            {
                this.CurrentManaPoint -= 3;
                Console.WriteLine(Name + " is charging the enemy!");
            }
            else
            {
                Console.WriteLine("You don't have enough Mana point charge the enemy");
            }

        }
    }
}
