using System.Collections.Generic;

namespace Farkle
{
    public interface IRules {
        int GetScore(List<int> values);
    }
}
