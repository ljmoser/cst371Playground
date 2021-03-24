using System;

namespace Farkle
{
    public class FarkleGame
    {
        public FarkleGame(IDiceRoller diceRoller, IRules rules)
        {
            DiceRoller = diceRoller;
            Rules = rules;
        }

        public IDiceRoller DiceRoller { get; }
        public IRules Rules { get; }
        public void Play()
        {
            var values = DiceRoller.RollDice(6);
            Console.WriteLine($"You rolled: {string.Join(", ", values)}");
            var score = Rules.GetScore(values);
            Console.WriteLine($"You scored: {score}");
        }
    }
}