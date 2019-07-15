using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;


namespace MonsterLibrary
{
    public class Ragdoll : Monster
    {
        public bool HasThrowsFlamingLitter { get; set; }

        public Ragdoll(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool hasThrowsFlamingLitter)
                : base (name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
            {
            HasThrowsFlamingLitter = hasThrowsFlamingLitter;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + (HasThrowsFlamingLitter ? "Throws a flaming cat litter" : "Melee Fighter");
        }//end ToString()

        public override int CalcBlock()
        {
            return HasThrowsFlamingLitter ? Block * 1 : Block;
        }//end CalcBlock()
    }//end class
}//end namespace
