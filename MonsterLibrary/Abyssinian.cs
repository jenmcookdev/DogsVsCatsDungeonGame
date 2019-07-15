using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;


namespace MonsterLibrary
{
    public class Abyssinian : Monster
    {
        public bool HasSwordSlash { get; set; }

        public Abyssinian(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool hasSwordSlash)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HasSwordSlash = hasSwordSlash;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + (HasSwordSlash ? "Goes into a frenzy and slashes out with sword" :  "Regular attack");
        }//end ToString()

        public override int CalcBlock()
        {
            return HasSwordSlash ? Block * 2 : Block;
        }//end CalcBlock()

    }//end class
}//end namespace
