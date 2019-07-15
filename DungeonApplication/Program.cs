using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"=-= Age Old War =-=";
            Console.WriteLine("The battle of canine vs feline");

            short killCount = 0;

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Race playerRace = Race.BostonTerrier;
            Console.WriteLine("Chose your race:\nB) BostonTerrier\nC) Chihuahua\nD) Dachshund\nG)" +
                " GermanShepherd\nI) IrishWolfhound\nM) Mastiff");
            ConsoleKey raceCHoice = Console.ReadKey(true).Key;
            switch (raceCHoice)
            {
                case ConsoleKey.B:
                    playerRace = Race.BostonTerrier;
                    break;
                case ConsoleKey.C:
                    playerRace = Race.Chihuahua;
                    break;
                case ConsoleKey.D:
                    playerRace = Race.Dachshund;
                    break;
                case ConsoleKey.G:
                    playerRace = Race.GermanShepherd;
                    break;
                case ConsoleKey.I:
                    playerRace = Race.IrishWolfhound;
                    break;
                case ConsoleKey.M:
                    playerRace = Race.Mastiff;
                    break;
                default:
                    Console.WriteLine("That was not one of the options, you shall now be a Boston Terrier.");
                    playerRace = Race.BostonTerrier;
                    break;
            }
            Console.WriteLine($"Welcome, {name} the {playerRace}! Your journey begins...");
            //Maybe have attack of opportunity and/or surprise attack
            //build weapon first as player uses weapon
            Weapon battleAxe = new Weapon("Rusty Battle Axe", 1, 6, 5, true);
            Player player = new Player(name, 60, 15, 80, 80, Race.BostonTerrier, battleAxe);
            bool exit = false;
            do
            {
                Console.WriteLine(GetRoom());

                Himalayan h1 = new Himalayan("Shorter Haired Himalayan", 20, 20, 8, 2, 1, 6, "A cream colored feline with brown points", false);
                Himalayan h2 = new Himalayan("Fluffy Himalayan", 30, 30, 13, 2, 4, 7, "A fluffy cream colored feline with brown points", true);
                Siamese s1 = new Siamese("Sensei Siamese", 30, 30, 10, 3, 6, 8, "Slender with a dark face and light fur covering the rest of its body", true);
                Siamese s2 = new Siamese("Yukyusha Siamese", 15, 15, 4, 1, 2, 4, "A younger feline with a lighter shaded face than and adult", false);
                Abyssinian a1 = new Abyssinian("Warrior Abyssinian", 25, 25, 12, 4, 5, 6, "Dark shaded fawn colored Abyssianian", true);
                Abyssinian a2 = new Abyssinian("Apprentice Abyssinian", 10, 10, 2, 1, 3, 5, "A younger darkly shaded fawn colored feline", false);
                Ragdoll r1 = new Ragdoll("Fluffy Puffy Ragdoll", 35, 35, 12, 1, 2, 8, "Very fluffy light color fur with cream-caramel shading and dark face", true);
                Ragdoll r2 = new Ragdoll("Shaved Ragdoll", 12, 12, 3, 3, 4, 6, "Light colored fur shaded in a creamy caramel color fur is shaved off in a lion cut", false);
                Munchkin m1 = new Munchkin("Fierce Munchkin", 35, 35, 12, 1, 2, 8, "Short-legged cat carrying a satchel full of catnip", true);
                Munchkin m2 = new Munchkin("clumsy Munchkin", 8, 8, 4, 3, 4, 6, "Uncordinated stubby legged feline that seems to not have much control over his legs.", false);
                Bengal b1 = new Bengal("Large Bengal", 35, 35, 15, 3, 4, 8, "A orange-tan colored spotted cat whose spots ripple as they move", true);
                Bengal b2 = new Bengal("Young Bengal", 8, 8, 4, 3, 4, 6, "A young spotted feline not to sure about war but trained to fight.", false);

                //Because all of our creatures will be of type Monster, they can be put into a collection of Monsters.
                List<Monster> monsters = new List<Monster>() { h1, h1, h2, h2, s1, s1, s2, s2, a1, a1, a2, a2, r1, r1, r2, r2, m1, m1, m2, m2, b1, b1, b2, b2 };
                Monster monster = monsters[new Random().Next(monsters.Count)];
                //square bracket [ ] used in this case is not an array but an index.

                Console.WriteLine("In this room: " + monster.Name); //to pull monster from List.


                bool reload = false;

                do
                {
                    Console.WriteLine("\nPlease choose and action:\n" +
                        "A) Attack\n" +
                        "R) RUN AWAY!\n" +
                        "P) Player stats\n" +
                        "M) Monster stats\n" +
                        "X) Exit");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        default:
                            Console.WriteLine("Thou hast chosen and improper option. Triest thou again.");
                            break;

                        case ConsoleKey.A:
                            Console.WriteLine("You move to attack the feline, but who will get the first strike?");
                            //random roll for initiative:
                            Random initiativeRoll = new Random();
                            int D20 = initiativeRoll.Next(1, 21);//range - display when not wanting to include 0
                            int monsterD20 = initiativeRoll.Next(1, 21); //monsters roll
                            Console.WriteLine("Player Roll: " + D20.ToString());
                            Console.WriteLine("Monster Roll: " + monsterD20.ToString());

                            if (D20 >= monsterD20) 
                            {
                                Console.WriteLine("Player attacks first");
                                CombatClass.DoAttack(player, monster);
                                if (monster.Life <= 0)
                                {
                                    killCount++;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"You have slain the {monster.Name}!");
                                    Console.ResetColor();
                                    reload = true;
                                }//end if
                            }
                            //TODO add monster first attack for initiative roll
                            else
                            {
                                Console.WriteLine("Monster attacks first");
                                CombatClass.DoAttack(monster, player);

                            }//end if initiative roll monster win


                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("You coward! You flee the room," +
                                $" but the {monster.Name} gets an attack of opportunity!");
                            CombatClass.DoAttack(monster, player);
                            reload = true;//to get out of inner loop back to outer loop
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine(player.ToString());
                            Console.WriteLine($"Creatures killed: {killCount}");
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("You have given up.");
                            exit = true; //exits both loops
                            break;
                    }//end switch - contains menu
                    if (player.Life <= 0)
                    {
                        exit = true;
                    }//end if
                } while (!exit && !reload); //inside loop
                //it's either going to be exit loop or reload the loop
            } while (!exit);//outside loop

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");

        }//end main()

        //room descriptions:
        private static string GetRoom()
        {
            string[] rooms =
            {
            "You find yourself in a large park that covers a wide area.  Small slopes and hills form to the east.  Many trees are scattered about the park shading a well worn path that weaves around the park and follows the edge of a lake.  A white gazebo sits on a small peninsula that juts out into the lake surrounded by flowers.   The park is oddly quiet at first, but suddenly you notice movement from the shrubs.",

            "You cry out a in surprise as the ground gives way causing you to tumble and slide down a steep muddy slope several feet before falling into an underground cavern.   The floor is littered with various size stones and clumps of dirt.  The walls of the cavern are damp, small stalagmites rise from the floor.  Looking around you notice a faint light down one of the corridors.  You decide to investigate and come upon a torch lit path.  Following the path you round a corner and find you are not alone.",

            "Noticing a farm you approach in the hopes of gaining supplies or at least a simple meal.  But it becomes apparent the farm was abandoned.  You reach the farm house and peer in the window confirming that it seems no one has been at the home in some time.  Seeing cans of food on a pantry shelf, you decide to pick the lock and make your way inside.  As you gather the food a thud upstairs draws your attention.  You slowly approach the staircase, but something jumps over the banister blocking your path.",

            "Moving vines aside you find a the entrance to a tunnel. The smooth brick and stone walls were created with precise craftsmanship.  The stone floor is well worn and covered in years of dust and debris. There are several fresh tracks leading into the tunnel.  You follow the tracks as the tunnel winds deeper into the mountain side and opens into a clearing surrounded by steep cliffs walls.  There is movement that darts into the shadows and you give chase...",

            "Wandering along the shoreline, you sink slightly into the sun warmed sand as you carefully scan your surroundings for danger.  As peaceful as the beach appeared, you knew you couldn’t let your guard down.  You think you see the silhouette of someone in the old weatherbeaten wooden dockhouse. Crouching down you move stealthily toward the dock and cross the floating wood platforms that still house a few small boats.  The door to the dockhouse is slightly open, you enter... ",

            "The large wrought iron gate protests in a long shrill squeak as you force it open.  You enter the cemetery listening intently for any sounds as the fog and darkness obscure your vision.  Your mind plays tricks on you as you move past the gravestones, you keep turning as you think you see movement out of the corner of your eye.  In the distance you can see the steeple of the church at the center of the cemetery and quicken your pace to reach it.  You begin to notice a hazy shape in the fog is getting more near.",
            };//end string[]   

            //Random rand = new Random();
            //int indexNbr = rand.Next(rooms.Length);
            //string roomDescription = rooms[indexNbr];
            //return roomDescription;

            return rooms[new Random().Next(rooms.Length)];//this one line does same as above code 106-109.

        }//end GetRoom()
         //reason not void, is that we want to return string

        //possible use of array to create a treasure or weapon drop system?

    }//end class
}//end namespace
