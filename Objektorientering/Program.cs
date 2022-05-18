using System;
using System.Collections.Generic;

namespace Objektorientering
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * Word guess
             * - Liste av ord som vi velger fra
             * - Sier ifra hvor mange bokstaver som er like / very cold, cold, hot, very hot
             */

            List<string> words = new List<string>
            {
                "Katt",
                "Hund",
                "Papegøye",
                "Elefant",
                "Mus"
            };

            var game = new WordGame(words);
            var game2 = new WordGame(words);
            var game3 = new WordGame(words);

            var activeGame = game;


            Console.WriteLine("Guess the random word!");
            while (activeGame.State)
            {
                var input = Console.ReadLine().ToLower();
                activeGame.Guess(input);
                Console.Clear();
                activeGame.Show();
            }

            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
        }
    }
}
