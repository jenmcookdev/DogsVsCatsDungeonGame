using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //for parent parameters

namespace MonsterLibrary
{
    public class Siamese : Monster
    {
            public bool HasKarateKicksWithSlashingClaws { get; set; }

            public Siamese(string name, int life, int maxLife, int hitChance, int block, int minDamage,
                int maxDamage, string description, bool hasKarateKicksWithSlashingClaws)
                : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
            {
            HasKarateKicksWithSlashingClaws = hasKarateKicksWithSlashingClaws;
            }//end FQCTOR

            public override string ToString()
            {
                return base.ToString() + (HasKarateKicksWithSlashingClaws ? "Attacks quickly slashing wildly with claws" : "Regular attack");
            }//end ToString()

            public override int CalcBlock()
            {
                return HasKarateKicksWithSlashingClaws ? Block * 3 : Block;
            }//end CalcBlock()

    }//end class
}//end namespace
