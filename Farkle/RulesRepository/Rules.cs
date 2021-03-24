using System.Collections.Generic;
using System.Linq;

namespace Farkle.RulesRepository
{
    public abstract class Rule
    {
        protected Rule nextRule;

        public Rule SetNext(Rule next)
        {
            this.nextRule = next;
            return next;
        }

        public int ProcessRule(List<int> values)
        {
            return ApplyRule(values) + ((nextRule?.ProcessRule(values)) ?? 0);
        }

        public abstract int ApplyRule(List<int> values);
    }

    public class Triplet : Rule
    {
        public Triplet(int n)
        {
            N = n;
        }

        public Triplet(int n, int overridePoints)
        {
            N = n;
            OverridePoints = overridePoints;
        }

        public int N { get; }
        public int? OverridePoints { get; private set; }
        public override int ApplyRule(List<int> values)
        {
            if (values.Count(x => N == x) >= 3)
            {
                values.Remove(N);
                values.Remove(N);
                values.Remove(N);

                return OverridePoints ?? N * 100;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Run : Rule
    {
        public override int ApplyRule(List<int> values)
        {
            if (values.Distinct().Count() == 6)
            {
                values.RemoveAll(x=>true);
                return 1500;
            }
            else
                return 0;
        }
    }

    public class CountN : Rule
    {
        public CountN(int n, int pointsPer)
        {
            N = n;
            PointsPer = pointsPer;
        }
        public int N { get; }
        public int PointsPer { get; }

        public override int ApplyRule(List<int> values)
        {
            return values.Count(x => x == N) * PointsPer;
        }
    }

    public class NOfAKind : Rule
    {
        public NOfAKind(int n, int points)
        {
            N = n;
            Points = points;
        }

        public int N { get; }

        public int Points { get; }

        public override int ApplyRule(List<int> values)
        {
            var matched = values
                .GroupBy(x=>x)
                .Select(x => new { value = x.Key, count = x.Count() })
                .FirstOrDefault(x=>x.count == N);

            if(matched != null)
            {
                values.RemoveAll(x=>x == matched.value);
                return Points;
            }
            else
                return 0;
        }
    }

    /*
    If sum of all number is greater than or equal to n, receive m points
    */
    public class MiniKnight : Rule
    {
        public MiniKnight(int n, int points)
        {
            N = n;
            Points = points;
        }

        public int N { get; }
        public int Points { get; }

        public override int ApplyRule(List<int> values)
        {
            int total = 0;
            foreach(var i in values)
            {
                total += i;
            }

            if(total >= N)
                return Points;
            else
                return 0;
        }
    }

    //This rule should give us 2200 points if the sum of all dice is a prime number
    public class MajorKnight : Rule
    {
        private readonly List<int> _primeNumbers = new List<int>();

        public MajorKnight()
        {
            for(int i = 0; i < 100; i++)
            {
                bool isPrime = true;
                for(int j = i-1; j > 1; j--)
                {
                    if(i%j == 0)
                    {
                        isPrime = false;
                    }
                }
                if(isPrime)
                    _primeNumbers.Add(i);
            }
        }
        public override int ApplyRule(List<int> values)
        {
            int sum = values.Sum();

            return _primeNumbers.Contains(sum) ? 2200 : 0;

        }
    }
}