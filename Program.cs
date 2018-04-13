using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu goTo = new Menu();
            List<Rounds> log = new List<Rounds>();
            Console.Write("What is your name: "); //user input name here instead of asking it all the time further on
            Characters playerName = new Characters { Name = Console.ReadLine() };

            while (true)
            {
                goTo.ChooseMenu(log);

            }

        }
        class Menu
        {
            public void ChooseMenu(List<Rounds> log)    //Menu list
            {
                Console.Clear();
                Battle Enter = new Battle();
                bool keepGoing = true;
                while (keepGoing)
                {
                    Console.WriteLine("1.Fight\n2.Retire 'Exit'\n3.Highscore");
                    char input = GetKey();
                    switch (input)
                    {
                        case '1':
                            Enter.Fight(log);
                            keepGoing = false;
                            break;
                        case '2':
                            Environment.Exit(0);
                            keepGoing = false;
                            break;
                        case '3':
                            Enter.ScoreList(log);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Not correct key");
                            break;
                    }
                }
                Console.ReadKey(true);

            }
            static char GetKey()    //easy mode to press"choose" your option
            {
                ConsoleKeyInfo userIn = Console.ReadKey(true);
                return userIn.KeyChar;
            }
        }
    }
}
