using Abilities;
using Stats;
using Utilities;
using System;

namespace Integration
{
    enum GameState
    {
        INIT = 0,
        PAUSED = 1,
        RUNNING = 2,
        EXIT = 3,
    }

    class Program
    {
        static void Main(string[] args)
        {
            FiniteStateMachine<GameState> fsm = new FiniteStateMachine<GameState>();
            
            fsm.AddTransition(GameState.INIT, GameState.PAUSED, PausedHandler);
            fsm.AddTransition(GameState.PAUSED, GameState.RUNNING, RunningHandler);
            fsm.AddTransition(GameState.RUNNING, GameState.PAUSED, PausedHandler);
            fsm.AddTransition(GameState.PAUSED, GameState.EXIT, ExitHandler);
            fsm.Start(GameState.INIT);
            Random r = new Random();

            for(int i = 0; i < 125; i++)
            {
                int s = r.Next(0, 4);
                fsm.ChangeState((GameState)s);
            }
        }

        static void ExitHandler()
        {
            System.Console.WriteLine("exit Action");
        }
        static void RunningHandler()
        {
            System.Console.WriteLine("running Action");
        }

        static void PausedHandler()
        {
            System.Console.WriteLine("Paused Action");
        }

        static void InitHandler()
        {
            System.Console.WriteLine("init Action");
        }
    }
}
