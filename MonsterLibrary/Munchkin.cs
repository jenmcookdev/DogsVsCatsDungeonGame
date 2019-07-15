using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;


namespace MonsterLibrary
{
    public class Munchkin : Monster
    {
        public bool HasCatNipPoisonBomb { get; set; }

        public Munchkin(string name, int life, int maxLife, int hitChance, int block, int minDamage,
            int maxDamage, string description, bool hasCatNipPoisonBomb)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HasCatNipPoisonBomb = hasCatNipPoisonBomb;
        }//end FQCTOR

        public override string ToString()
        {
            return base.ToString() + (HasCatNipPoisonBomb ? "Thows Catnip Poison Bomb sickening you" :  "Regular attack");
        }//end ToString()

        public override int CalcBlock()
        {
            return HasCatNipPoisonBomb ? Block * 2 : Block;
        }//end CalcBlock()

    }//end class
}//end namespace
