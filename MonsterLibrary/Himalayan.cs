using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;


namespace MonsterLibrary
{
    public class Himalayan : Monster
    {
        public bool HasEntanglingHair { get; set; }

        public Himalayan(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool hasEntanglingHair)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HasEntanglingHair = hasEntanglingHair;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + (HasEntanglingHair ? "Tries to ensnare you with its long fur" :  "Regular attack");
        }//end ToString()

        public override int CalcBlock()
        {
            return HasEntanglingHair ? Block * 2 : Block;
        }//end CalcBlock()

    }//end class
}//end namespace
