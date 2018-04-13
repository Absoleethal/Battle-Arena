using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class Rounds
    {
        int match = 1; //for score list down in the information (this could probably be made waayy better)
        public int playerWon { get; set; } //How many times i have won inserted
        public int npcWon { get; set; } //How many times i have lost Inserted

        public Rounds(int won, int lost)
        {
            playerWon = won;
            npcWon = lost;
        }

        public void Information() //information to print
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"On {match++}st match Player has {playerWon} win and NPC has {npcWon} Win");

            Console.ResetColor();


        }
    }
}
