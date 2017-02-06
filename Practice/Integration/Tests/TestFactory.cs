using Abilities.ConcreteAbilities;
using Abilities.ConcreteEntities;
using Abilities;
using Stats;
using System;


namespace Integration
{
    public enum TestType
    {
        ABILITY,
        STATS
    }
    public class TestFactory
    {
        private Action onRun;

        public TestFactory()
        {
            
        }

        public TestFactory(TestType t)
        {
            switch(t)
            {
                case TestType.STATS:

                    onRun += delegate
                    {

                        Stat[] unit_stats = {
                            new Stat("str", 10),
                            new Stat("int", 10),
                            new Stat("spd", 10)
                        };

                        Stats.Stats stats = new Stats.Stats(unit_stats);

                        stats.AddModifier(2, new Modifier("mult", "int", 2));
                        stats.RemoveModifier(2);
                        stats.AddModifier(3, new Modifier("mult", "int", 2));
                        stats.AddModifier(4, new Modifier("mult", "int", 2));
                        stats.AddModifier(5, new Modifier("mult", "int", 5));
                        stats.AddModifier(6, new Modifier("mult", "int", -5));
                        stats.RemoveModifier(6);
                        stats.ClearModifiers();
                        stats.AddModifier(3, new Modifier("mult", "int", 2));
                        stats.AddModifier(4, new Modifier("mult", "int", 2));
                        stats.AddModifier(5, new Modifier("mult", "int", 5));
                        stats.AddModifier(6, new Modifier("mult", "int", -5));

                    };
                    break;
                case TestType.ABILITY:
                    onRun += delegate
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
                    };
                    break;
                default:
                    break;
            }
        }
        
        public void Run()
        {
            if(onRun != null)
                onRun.Invoke();           
        }
    }
}
