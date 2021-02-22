using System;
using System.Collections.Generic;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
           FarkleGame game = new FarkleGame();
           game.DiceRoller = new D6Roller();
           Console.Write(game.Play());

        }
    }
}
