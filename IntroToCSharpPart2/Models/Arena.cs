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

        public void AddFighter(ILivingThing creature)
        {
            listOfLivingCreatures[0] = creature;
        }

        public void RoyalRumble()
        {
            foreach(var livingCreature in listOfLivingCreatures)
            {
                var randomCreatureToAttack = listOfLivingCreatures[new Random().Next(listOfLivingCreatures.Length)];
                livingCreature.Attack(randomCreatureToAttack);
            }
        }


        ILivingThing[] listOfLivingCreatures;
    }
}
