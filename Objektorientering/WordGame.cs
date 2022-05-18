using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektorientering
{

    internal class WordGame
    {
        private readonly Random rnd = new Random();

        //Properties
        public bool State { get; private set; }
        public List<string> WordList { get; private set; }
        private string _randomWord;
        private double _correctPercent;


        //Constructor
        public WordGame(List<string> wordList)
        {
            WordList = wordList;
            _randomWord = WordList[rnd.Next(0, WordList.Count)].ToLower();
            State = true;
        }

        //Metoder
        public void Show()
        {
            var answer = "";
            switch (_correctPercent)
            {
                case < 0.25:
                    answer = "very cold";
                    break;
                case < 0.50:
                    answer = "cold";
                    break;
                case < 0.75:
                    answer = "hot";
                    break;
                case < 0.99:
                    answer = "very hot";
                    break;
                case 1:
                    answer = "correct";
                    State = false;
                    break;
                default:
                    answer = "above 1 ?";
                    break;
            }
            Console.WriteLine($"You guess was {answer}!"); //very cold 0 - 25, cold 25 - 50, hot 50 - 75, very hot 75 - 99, correct! 100
        }

        public void Guess(string guess)
        {
            if (guess == _randomWord)
            {
                _correctPercent = 1;
            }
            else if (guess.Length > _randomWord.Length + 2)
            {
                _correctPercent = 0.25;
            }
            else
            {
                var count = 0D;
                foreach (var c in guess)
                {
                    if (_randomWord.Contains(c))
                    {
                        count++;
                    }
                }

                _correctPercent = count / _randomWord.Length;

            }


        }

    }
}
