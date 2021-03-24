using System;
using System.Collections.Generic;
using Farkle;
using Farkle.RulesRepository;
using Microsoft.Extensions.Configuration;
using StructureMap;

namespace Playground
{
    public static class Program
    {

        public static void Main()
        {
            for(int i = 0; i< 10000; i++)
            {
                var game = new FarkleGame(new D6Roller(), new GrandmasRules());
                game.Play();
            }

        }
    }
}



