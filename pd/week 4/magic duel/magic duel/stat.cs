using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magic_duel
{
    class Stats
    {
        // Data members
        public string Name;
        public double Damage;
        public double Penetration;
        public double Heal;
        public double Cost;
        public string Description;

        // Constructor: note that the order is (name, damage, penetration, heal, cost, description)
        public Stats(string name, double damage, double penetration, double heal, double cost, string description)
        {
            Name = name;
            Damage = damage;
            Penetration = penetration;
            Heal = heal;
            Cost = cost;
            Description = description;
        }
    }
}
