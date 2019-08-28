using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntroToCSharpPart2.Models
{
    class Monster : ILivingThing
    {
        public int HP { get; set; }

        public string Loot;
        public DateTime deathTime;

        public string[] KilledHeroes;

        public void Attack(ILivingThing enemy)
        {
            Console.WriteLine("I'm a monster: GRRRR on " + enemy.ToString());
        }


        //IF a return value is required Task<typeOfReturnValue> like Task<double>
        //IF a return value is not require, just Task
        public async Task KillSomebody()
        {
            Console.WriteLine("I'm executed in a separate thread");
            //return this;
        }
    }
}
