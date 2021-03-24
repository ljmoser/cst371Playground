using System;
using System.Collections.Generic;

namespace Farkle
{
    public class UnfairD6Roller : IDiceRoller
    {
        public List<int> RollDice(int n)
        {
            Random r = new Random();

            List<int> values = new List<int>();

            for(int i = 0; i < n; i++)
            {
                int value = r.Next(1, 10) > 2 ? 6 : r.Next(1,7);

                values.Add(value);
            }

            return values;
        }
    }
}