using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{   //The abstract keyword indicates that the thing being modified is an incomplete implementation,
    //meaning it is never intended to be instantiated on its own.
    //When applied to a class it indicates that the class is only intended to be a parent class
    //for child classes.  Abstract gives us a compiler-enforced room that prevents instantiation 
    //of the class.
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end Life

        public virtual int CalcBlock()
        {
            //We made this virtual so we can override it in child classes
            return Block;
        }//end CalcBlock()

        //MINI-LAB!
        //Build the CalcHitChange() and make it return HitChance
        //Make it overridable

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        //public virtual int CalcDamage()
        //{
        //    return 0;
        //    //Player and Monster calculate damage differently, so we can't have default
        //    //functionality like we do for HitChance and Block.Instead, we're just 
        //    //returning 0 and we will override functionality in the derived classes.
        //}//end CalcDamage()

        public abstract int CalcDamage(); 
        //The abstract keyword FORCES child classes to override this functionality
        //by providing the method body. This prevents the possible mistake of returning
        //zero which could happen with the above virtual version.
        //when you do a method as an abstract you don't need the { } as you aren't defining anything.
        //similar to the above virtual one but in one line forces override to have to occur in the derived class.

}//end class
}//end namespace
