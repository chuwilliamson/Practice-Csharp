using Abilities.ConcreteAbilities;
using Abilities.ConcreteEntities;
using Abilities;
using RPGStats;
using System;
using System.Diagnostics;

namespace Integration.Tests
{
    public class TestAbility
    {
        public TestAbility()
        {
            var guy = new Cactuar("Cactus guy", 125, 25);
            var girl = new Cactuar("Cactus girl", 80, 100);
            ILogger Debug = new Logger();
            Debug.Log("Guy Status: " + guy.Status);
            Debug.Log("Girl Status: " + girl.Status);

            for(var input = Console.ReadLine(); !string.Equals(input, "q"); input = Console.ReadLine())
            {
                Console.Clear();

                Debug.Log("Guy Status: " + guy.Status);
                Debug.Log("Girl Status: " + girl.Status);

                switch(input)
                {
                    case "w":
                        girl.Add("ThousandNeedles", new ThousandNeedles(25, 28));
                        girl.Cast("ThousandNeedles", guy);
                        break;
                    case "a":
                        girl.Add("Grenade", new Grenade(5, 25));
                        girl.Cast("Grenade", guy);
                        break;
                    case "s":
                        guy.Add("GuyGrenade", new Grenade(5, 15));
                        guy.Cast("GuyGrenade", guy);
                        break;
                    case "d":
                        guy.Add("Cure", new Cura(5, 5));
                        guy.Cast("Cure", guy);
                        break;
                    default:
                        Debug.Log("NO...");
                        break;
                }
            }

            Debug.Log("Program Complete..");
        }
    }
}

