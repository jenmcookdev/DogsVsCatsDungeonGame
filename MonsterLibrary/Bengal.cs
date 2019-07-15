using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;


namespace MonsterLibrary
{
    public class Bengal : Monster
    {
        public bool HasHypnoticSpots { get; set; }

        public Bengal(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool hasHypnoticSpots)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HasHypnoticSpots = hasHypnoticSpots;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + (HasHypnoticSpots ? "Rippling spots has hypnotic effect on target" :  "Regular attack");
        }//end ToString()

        public override int CalcBlock()
        {
            return HasHypnoticSpots ? Block * 2 : Block;
        }//end CalcBlock()

    }//end class
}//end namespace
