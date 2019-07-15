using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {

        //propfull will auto type a field & property
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;

            }//end set MinDamage
        }//end MinDamage

        public Monster(string name, int life, int maxLife, int hitChance, int block, 
            int minDamage, int maxDamage, string description)
        {
            MaxDamage = maxDamage;
            MaxLife = maxLife;
            Name = name;
            Block = block;
            Life = life;
            HitChance = hitChance;
            MinDamage = minDamage;
            Description = description;
        }//end FQCTOR

        public override string ToString()
        {
            return string.Format($"\n******** MONSTER STATS ********\n{Name}\nLife: {Life} of {MaxLife}\n" +
                $"Damage: {MinDamage} to {MaxDamage}\nBlock: {Block}%\nDescription: {Description}\n");
        }//end Tostring()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage()


    }//end class
}//end namespace
