using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magic_duel
{
    public class player
    {
        public string name;
        public float maxhealth;
        public float health;
        public float maxenergy;
        public float armor;
        public player(string name, float maxhealth, float health, float maxenergy, float armor)
        {
            this.name = name;
            this.maxhealth = maxhealth;
            this.health = health;
            this.maxenergy = maxenergy;
            this.armor = armor;

        }
    }
}
