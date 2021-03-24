using System;
using System.Collections.Generic;

namespace Farkle
{
    public class D6Roller : IDiceRoller
    {
        public List<int> RollDice(int n)
        {
            Random r = new Random();

            List<int> values = new List<int>();

            for(int i = 0; i < n; i++)
                values.Add(r.Next(1,7));

            return values;
        }
    }
}