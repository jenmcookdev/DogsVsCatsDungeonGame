using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class CombatClass
    {//We don't want this one to be the default instance method
        public static void DoAttack(Character attacker, Character defender)
        {

            Random rando = new Random();
            int diceRoll = rando.Next(1, 101);
            System.Threading.Thread.Sleep(1000);
            if (diceRoll <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{attacker.Name} dealt {damageDealt} to {defender.Name}!");

                Console.ResetColor();
            }//end if
            else
            {
                Console.WriteLine($"{defender.Name} dodged their attack!");
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);
            if (monster.Life >= 1)
            {
                DoAttack(monster, player);
            }//end if

        }//end DoBattle()
    }//end class
}//end namespace
//future - change code so both player and monster roll initiative and make it where it just rolls once.