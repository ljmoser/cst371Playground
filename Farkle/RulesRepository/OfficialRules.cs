using System.Collections.Generic;
using System.Linq;
using Farkle.RulesRepository;

namespace Farkle
{
    public class OfficialRules : IRules
    {
        public int GetScore(List<int> values)
        {
            Rule initialRule = new NOfAKind(6, 3000);

            initialRule
                .SetNext(new NOfAKind(5, 2000))
                .SetNext(new NOfAKind(4, 1000))
                .SetNext(new Triplet(6))
                .SetNext(new Triplet(6))
                .SetNext(new Triplet(5))
                .SetNext(new Triplet(5))
                .SetNext(new Triplet(4))
                .SetNext(new Triplet(4))
                .SetNext(new Triplet(3))
                .SetNext(new Triplet(3))
                .SetNext(new Triplet(2))
                .SetNext(new Triplet(2))
                .SetNext(new Triplet(1))
                .SetNext(new Triplet(1))
                .SetNext(new Run())
                .SetNext(new CountN(5, 50))
                .SetNext(new CountN(1, 100));

            return initialRule.ProcessRule(values);
        }
    }
}
