using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
        //player will be errored when an abstract method is added in the parent
        //It will go away once we set the abstracts parameters in the child
    {
        //moved properties similar to monster to Character class
        //fields
        //private int _life;

        /*
         * Automatic properties were introduced with .Net 3.5. They are a shortcut
         * syntax that allows you to quickly build a property without a field.
         * Instead, the field gets built by the compiler at runtime and automatically
         * tied to the property. You cannot use automatic properties for any property
         * with a business rule, so we have to have a field for Life, as it is going
         * to have a rule that it cannot be more than MaxLife.
         * 
         * prop tab tab change datatype and name then enter enter
         */

        //properties
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int Block { get; set; }
        //public int MaxLife { get; set; }
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        _life = value <= MaxLife ? value : MaxLife; 
        //    }//end set
        //}//end Life


        //ctors
        //MINI-LAB! build a FQCTOR
        public Player(string name, int hitChance, int block, int maxLife, int life, 
            Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }//end FQCTOR


        //methods

        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)//type switch tab tab enter name and hit enter to display list from other class
            {
                case Race.BostonTerrier:
                    description = "You can be quite clown-like at times and fierce the rest of the time. You tend to have a stubborn streak and often will pout if you don't get your way.";
                    break;
                case Race.Chihuahua:
                    description = "You are quite short and yappy.  You tend to forget your size and act like the biggest dog out there.";
                    break;
                case Race.Dachshund:
                    description = "You are low to the ground and have a slight waddle when you walk.  You can be quite bold and get into small places easily.";
                    break;
                case Race.GermanShepherd:
                    description = "You tend to take charage and are always alert and ready for anything.";
                    break;
                case Race.IrishWolfhound:
                    description = "You are calm, dignified and agreeable, but fearless when situations require it.";
                    break;
                case Race.Mastiff:
                    description = "You are patient, protective and oddly gentle for your size despite how powerful you can be.";
                    break;

                default:
                    break;
            }//end switch
                     
            return string.Format("=-=-={0}=-=-=\nLife: {1} of {2}\nHit Chance: {3}%\n Weapon:\n" +
                "{4}\n Block: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block,
                description);
                                                    
                }//end ToString

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance ;
            //using HitChance because in parent we have the CalcHitChance returning HitChance
            //can also use base.CalcHitChance() in place of the HitChance
        }//end CalcHitChance()

        public override int CalcDamage()
        {
            //Random rand = new Random();
            //int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //return damage;

            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //this one line above replaces the 3 lines above it, but is more compact and efficient.
        }//end CalcDamage()



    }//end class
}//end namespace
