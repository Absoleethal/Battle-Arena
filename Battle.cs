using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class Battle
    {
        int won;
        int lost;
        public void TextColor(string text, ConsoleColor color) //Easier to write text in which ever color i choose
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void Fight(List<Rounds> log)
        {

            Console.Clear();
            Console.WriteLine("Getting the random attributes");
            Random dice = new Random();
            Characters playerSet = new Characters(dice.Next(2,8), dice.Next(2,8),dice.Next(2,8)); //Player character random attributes
            Characters npcSet = new Characters(dice.Next(2, 8), dice.Next(2, 8), dice.Next(2, 8)); //NPC random attributes

            InfoGenerator NPC = new InfoGenerator(DateTime.Now.Millisecond);       // 
            Gender Sex = Gender.Male;                                              //NPC random name
            Characters npcName = new Characters { Name = NPC.NextFirstName(Sex)}; ///
                                                                                   

            Console.WriteLine($"Your DMG: {playerSet.Damage} HP: {playerSet.Health} STR: {playerSet.Strength}");
            Console.WriteLine($"{npcName.Name} DMG: {npcSet.Damage} HP: {npcSet.Health} STR: {npcSet.Strength}");
            TextColor("- Prepare to Fight -(Press any key)", ConsoleColor.Green);
            Console.ReadKey(true);

            do
            {
                playerSet.Strength += playerSet.Strength + dice.Next(2, 8); //adds new random set of to strength to strength
                npcSet.Strength += npcSet.Strength + dice.Next(2,8);
                TextColor($"Your new Strenght is: {playerSet.Strength}\n{npcName.Name} Strength is: {npcSet.Strength}",ConsoleColor.Green);

                if (playerSet.Strength > npcSet.Strength) //if playerstrenght is highter than NPCs then...
                {
                    npcSet.Health -= playerSet.Damage;
                    TextColor($"You hit {npcName.Name} with {playerSet.Damage}",ConsoleColor.Magenta);
                    Console.WriteLine($"{npcName.Name} HP is: {npcSet.Health}");
                }
                else if (npcSet.Strength > playerSet.Strength)  //if NPC strength is higher than Player then...
                {
                    playerSet.Health -= npcSet.Damage;
                    TextColor($"{npcName.Name} hit you with {npcSet.Damage}",ConsoleColor.Red);
                    Console.WriteLine($"Your HP is: {playerSet.Health}");
                }
                else //the possibility that both player and NPC has the same amount of strength then ....
                {
                    TextColor("Parry!! both participant looses 1 DMG",ConsoleColor.Green);
                    playerSet.Damage -= 1;
                    npcSet.Damage -= 1;
                    Console.WriteLine($"Your DMG is now {playerSet.Damage}\n{npcName.Name} DMG is now {npcSet.Damage}");
                }

            } while (playerSet.Health > 0 && npcSet.Health > 0);

            if (playerSet.Health <= 0) //if player health is less or equal to 0 then...
            {
                lost++;
                TextColor("You Loose",ConsoleColor.Red);
                log.Add(new Rounds(0,lost));
            }
            else //else you won ;)
            {
                
                won++;
                TextColor("You Win", ConsoleColor.Yellow);
                log.Add(new Rounds(won, 0));
            }
           


        }
        public void ScoreList(List<Rounds> log) //Scorelist
        {
            foreach (var item in log) 
            {
                item.Information();
            }
        }

    }
}
