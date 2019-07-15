using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        
        //properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set MinDamage
        }//end MinDamage

        //constructors
        //Only FQCTOR
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        {
            //The order that the parameters are placed in doesn't matter at all. The order
            //they are assigned in is critical if we have properties whose business rules
            //rely on the value of other properties. In that case it's best to set the
            //dependant values first: in this case we set maxDamage first as MinDamage relies on it

            MaxDamage = maxDamage;
            Name = name;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//end FQCTOR Weapon() 

        //methods
        public override string ToString()
        {
            //return base.ToString();
            //the default base.ToString() for complex objects is namespace.Classname
            //which we do not want.

            return string.Format("Name: {0}\tMin Damage: {1} Max Damage: {2}\nBonus Hit Chance: {3}%\tIs Two Handed: {4}",
                Name,
                MinDamage,
                MaxDamage,
                BonusHitChance,
                IsTwoHanded == true ? "yes" : "no");//watch spaces

            //MINI-LAB!
            //Build a ternary operator to output whether or not the weapon is two handed.
            // ^^^(above)^^^

        }//end override ToString
    }//end class
}//end namespace
