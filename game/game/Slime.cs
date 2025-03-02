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
        
        public Slime(string name) : base ( name, 1, 1, 1, 3, 2, 1, 0, 1)
        {
            base.name = this.name;
            base.xp = 2;         
        }

    }
}
