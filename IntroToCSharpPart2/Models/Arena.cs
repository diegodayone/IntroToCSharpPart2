using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    class Arena
    {
        public void Fight(ILivingThing attacker, ILivingThing attacked)
        {
            attacker.Attack(attacked);
        }
    }
}
