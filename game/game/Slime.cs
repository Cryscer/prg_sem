using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Slime : Character
    {
        string name;
        public Slime() 
        {
            base.name = "slime";
            base.strength = 1;
            base.endurance = 1;
            base.dexterity = 1;
            base.attackBonus = 1;            
        }

    }
}
