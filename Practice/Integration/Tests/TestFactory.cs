using Abilities.ConcreteAbilities;
using Abilities.ConcreteEntities;
using Abilities;
using Stats;
using System;
using System.Diagnostics;
using Utilities.Assessment_4;

namespace Integration
{
    public enum GameState
    {
        INIT = 0,
        RUNNING = 1,
        PAUSED = 2,
        EXIT = 3,
    }
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

        static void TestTrent(string[] arguments)
        {


            foreach(var s in arguments)
            {
                if(s == "-d")
                    Console.WriteLine("START IN DEBUG MODE");
            }

            FSM<GameState> FSM_gamestate = new FSM<GameState>();
            FSM_gamestate.AddStateFunction("onEnter", GameState.INIT, (Action)InitEnter);
            FSM_gamestate.AddStateFunction("onexit", GameState.INIT, (Action)InitExit);

            FSM_gamestate.AddStateFunction("ONENTER", GameState.RUNNING, (Action)RunningEnter);
            FSM_gamestate.AddStateFunction("onexit", GameState.RUNNING, (Action)RunningExit);

            FSM_gamestate.AddStateFunction("ONENTER", GameState.PAUSED, (Action)PausedEnter);
            FSM_gamestate.AddStateFunction("onexit", GameState.PAUSED, (Action)PausedExit);

            FSM_gamestate.AddStateFunction("ONENTER", GameState.EXIT, (Action)ExitEnter);
            FSM_gamestate.AddStateFunction("onexit", GameState.EXIT, (Action)ExitExit);


            FSM_gamestate.AddTransition(GameState.INIT, GameState.PAUSED);
            FSM_gamestate.AddTransition(GameState.PAUSED, GameState.RUNNING);
            FSM_gamestate.AddTransition(GameState.RUNNING, GameState.PAUSED);
            FSM_gamestate.AddTransition(GameState.PAUSED, GameState.EXIT);
            FSM_gamestate.StartMachine(new State(GameState.INIT));
            Test1(FSM_gamestate);
            FSM_gamestate.StartMachine(new State(GameState.INIT));
            Test2(FSM_gamestate);
        }
        public static void Test2(FSM<GameState> fsm)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            fsm.ChangeState(new State((GameState)0));
            while(sw.ElapsedMilliseconds < (25 * 1000))
            {
                for(int i = 1; i < 1000; i++)
                {
                    int s = i % 2 + 1;
                    fsm.ChangeState(new State((GameState)s));
                }
            }
            fsm.ChangeState(new State((GameState)3));
        }
        public static void Test1(FSM<GameState> fsm)
        {
            //0,1,2,3
            fsm.ChangeState(new State((GameState)0));
            fsm.ChangeState(new State((GameState)1));
            fsm.ChangeState(new State((GameState)2));
            fsm.ChangeState(new State((GameState)3));
        }

        public static void InitExit()
        {
            System.Console.WriteLine("Exit init handler");
        }
        public static void InitEnter()
        {
            System.Console.WriteLine("Enter init handler");
        }
        public static void RunningExit()
        {
            System.Console.WriteLine("Exit running handler");
        }
        public static void RunningEnter()
        {
            System.Console.WriteLine("Enter running handler");
        }
        public static void PausedExit()
        {
            System.Console.WriteLine("Exit paused handler");
        }
        public static void PausedEnter()
        {
            System.Console.WriteLine("Enter paused handler");
        }
        public static void ExitEnter()
        {
            System.Console.WriteLine("Enter exit handler");
        }
        public static void ExitExit()
        {
            System.Console.WriteLine("exit exit handler");

        }
    }
}
