using System;
using Xunit;
using Farkle.RulesRepository;
using System.Collections.Generic;

namespace FarkleTests
{
    public class IRuleTests
    {
        [Fact]
        public void Triple_1_NotHit()
        {
            Triplet rule = new Triplet(1);
            var points = rule.ProcessRule(new List<int>{1,2,3,4,5,6});
            Assert.Equal(0, points);

        }

        [Fact]
        public void Triple_1_HitOnce()
        {
            Triplet rule = new Triplet(1);
            var points = rule.ProcessRule(new List<int>{1,1,1,3,3,3});
            Assert.Equal(100, points);
        }

        [Fact]
        public void Triple_1_HitOnce_WithOverride()
        {
            Triplet rule = new Triplet(1, 1000);
            var points = rule.ProcessRule(new List<int>{1,1,1,2,2,2});
            Assert.Equal(1000, points);
        }

        [Fact]
        public void Run_Hit()
        {
            var rule = new Run();
            var points = rule.ProcessRule(new List<int>{1,4,3,2,5,6});
            Assert.Equal(1500, points);
        }

        [Fact]
        public void Run_NotHit()
        {
            var rule = new Run();
            var points = rule.ProcessRule(new List<int>{1,2,3,4,5,5});
            Assert.Equal(0, points);
        }

        [Fact]
        public void ProcessNextTest()
        {
            var rule1 = new Triplet(1);
            rule1.SetNext(new Triplet(3));

            var points = rule1.ProcessRule(new List<int>{1,1,1,3,3,3});
            Assert.Equal(400, points);

        }
    
    
        [Fact]
        public void MiniKnight_Hit_GreaterThan()
        {
            var expectedPoints = 50;
            var rule = new MiniKnight(10, expectedPoints);
            var points = rule.ProcessRule(new List<int>{1,2,3,4,5,5});
            Assert.Equal(expectedPoints, points);
        }
    
        [Fact]
        public void MiniKnight_Hit_Equal()
        {
            var expectedPoints = 50;
            var rule = new MiniKnight(10, expectedPoints);
            var points = rule.ProcessRule(new List<int>{1,1,1,1,4,2});
            Assert.Equal(expectedPoints, points);
        }
    
        [Fact]
        public void MiniKnight_NotHit()
        {
            var valueIfHit = 50;
            var rule = new MiniKnight(10, valueIfHit);
            var points = rule.ProcessRule(new List<int>{1,2,1,1,1,1});
            Assert.Equal(0, points);
        }

        [Fact]
        public void MajorKnight_Hit()
        {
            var expectedPoints = 2200;
            var rule = new MajorKnight();
            var points = rule.ProcessRule(new List<int>{5,5,5,5,2,1});
            Assert.Equal(expectedPoints, points);
        }
    
        [Fact]
        public void MajorKnight_NotHit()
        {
            var rule = new MajorKnight();
            var points = rule.ProcessRule(new List<int>{1,2,2,1,1,1});
            Assert.Equal(0, points);
        }

    }
}
