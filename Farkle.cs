using System;
using System.Collections.Generic;
using System.Linq;

namespace Playground
{

    public interface Rules {
        int GetScore(List<int> values);
    }
    public static class GrandmasRules
    {
        public static int MaxScore {get;set;}
        public static int GetScore(List<int> values)
        {
            int totalPoints = 0;

            //handle sets of three 6s
            if(values.Count(x=>x == 6) >=3)
            {
                values.Remove(6);
                values.Remove(6);
                values.Remove(6);
                totalPoints = totalPoints + 600;
            }
            if(values.Count(x=>x == 6) >=3)
            {
                values.Remove(6);
                values.Remove(6);
                values.Remove(6);
                totalPoints = totalPoints + 600;
            }



            //handle sets of three 5s
            if(values.Count(x=>x == 5) >=3)
            {
                values.Remove(5);
                values.Remove(5);
                values.Remove(5);
                totalPoints = totalPoints + 500;
            }
            if(values.Count(x=>x == 5) >=3)
            {
                values.Remove(5);
                values.Remove(5);
                values.Remove(5);
                totalPoints = totalPoints + 500;
            }



            //handle sets of three 4s
            if(values.Count(x=>x == 4) >=3)
            {
                values.Remove(4);
                values.Remove(4);
                values.Remove(4);
                totalPoints = totalPoints + 400;
            }
            if(values.Count(x=>x == 4) >=3)
            {
                values.Remove(4);
                values.Remove(4);
                values.Remove(4);
                totalPoints = totalPoints + 400;
            }



            //handle sets of three 3s
            if(values.Count(x=>x == 3) >=3)
            {
                values.Remove(3);
                values.Remove(3);
                values.Remove(3);
                totalPoints = totalPoints + 300;
            }
            if(values.Count(x=>x == 3) >=3)
            {
                values.Remove(3);
                values.Remove(3);
                values.Remove(3);
                totalPoints = totalPoints + 300;
            }



            //handle sets of three 2s
            if(values.Count(x=>x == 2) >=3)
            {
                values.Remove(2);
                values.Remove(2);
                values.Remove(2);
                totalPoints = totalPoints + 200;
            }
            if(values.Count(x=>x == 2) >=3)
            {
                values.Remove(2);
                values.Remove(2);
                values.Remove(2);
                totalPoints = totalPoints + 200;
            }



            //handle sets of three 1s
            if(values.Count(x=>x == 1) >=3)
            {
                values.Remove(1);
                values.Remove(1);
                values.Remove(1);
                totalPoints = totalPoints + 1000;
            }
            if(values.Count(x=>x == 1) >=3)
            {
                values.Remove(1);
                values.Remove(1);
                values.Remove(1);
                totalPoints = totalPoints + 1000;
            }

            HashSet<int> distinctValues = new HashSet<int>(values);
            if(distinctValues.Count == 6)
            {
                return 1500;
            }
           
            int numberOf5s = values.Count(x=>x == 5);
            int numberOf1s = values.Count(x=>x == 1);

            return totalPoints + numberOf5s*50 + numberOf1s * 100;
        }
    }

    public static class OfficialRules
    {
        public static int GetScore(List<int> values)
        {
            return 798;
        }
    }

    public interface IDiceRoller {
        List<int> RollDice(int n);
    }
    public class D6Roller : IDiceRoller
    {
        public static int NumberOfSides = 6;
        public List<int> RollDice(int n)
        {
            var rand = new Random();
            var values = new List<int>(){
                rand.Next(7),
                rand.Next(7),
                rand.Next(7),
                rand.Next(7),
                rand.Next(7),
                rand.Next(7)
            };
            return values;
        }   
    }


    public class Config
    {
        private Config()
        {
            //read from config file
        }

        public string ApiKey {get;set;}

        private static Config _ConfigInstance;
        public static Config ConfigInstance
        {
            get
            {
                if(_ConfigInstance == null)
                    _ConfigInstance = new Config();

                return _ConfigInstance;
            }
        }
    }


    public class FarkleGame
    {
        public IDiceRoller DiceRoller {get;set;}
        public int Play()
        {

            string apiKey = Config.ConfigInstance.ApiKey;

            var values = DiceRoller.RollDice(6);
            return GrandmasRules.GetScore(values);

       }
    }

}