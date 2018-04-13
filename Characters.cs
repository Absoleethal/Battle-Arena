using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class Characters
    {



        public string Name { get; set; }   
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Characters()
        {

        }
        public Characters(int Damage, int Health, int Strength)
        {
            this.Damage = Damage;
            this.Health = Health;
            this.Strength = Strength;
        }

    }
    
}
