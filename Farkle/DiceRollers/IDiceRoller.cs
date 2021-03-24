using System.Collections.Generic;

namespace Farkle
{
    public interface IDiceRoller {
        List<int> RollDice(int n);
    }
}