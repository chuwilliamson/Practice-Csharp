using System;
using Utilities;
namespace CombatForms.Scripts
{
    enum GameState
    {
        INIT = 0,
        START = 1,
        PAUSED = 2,
        RUNNING = 3,
        EXIT = 4,
    }

    class GameSingleton
    {
        GameSingleton()
        {
            
        }
        public void Init()
        {
            fsm = new FiniteStateMachine<GameState>();
            fsm.AddTransition(GameState.INIT, GameState.START, onStart);
            onStart += StartHandler;
            fsm.AddTransition(GameState.START, GameState.RUNNING, RunningHandler);
            //  onRunning += RunningHandler;
            fsm.AddTransition(GameState.PAUSED, GameState.RUNNING, RunningHandler);
            // onRunning += RunningHandler;
            fsm.AddTransition(GameState.RUNNING, GameState.PAUSED, PausedHandler);
            //  onPaused += PausedHandler;
            fsm.AddTransition(GameState.PAUSED, GameState.EXIT, ExitHandler);
            //  onExit += ExitHandler;
            fsm.Start(GameState.INIT);
            fsm.ChangeState(GameState.START);
        }

        Action onPaused;
        Action onStart;
        Action onExit;
        Action onRunning;

        public void AddTo(GameState state, Action h)
        {
            switch(state)
            {
                case GameState.START:
                    onStart += h;
                    break;
                case GameState.PAUSED:
                    onPaused += h;
                    break;
                case GameState.RUNNING:
                    onRunning += h;
                    break;
                case GameState.EXIT:
                    onExit += h;
                    break;
            }
        }
        private static readonly GameSingleton instance = new GameSingleton();
        public static GameSingleton Instance
        {
            get
            {
                return instance;
            }
        }
        FiniteStateMachine<GameState> fsm;
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
        static void StartHandler()
        {
            System.Console.WriteLine("start Action");
        }
        static void InitHandler()
        {
            System.Console.WriteLine("init Action");
        }
        public void Test()
        {
            Random r = new Random();

            for(int i = 0; i < 125; i++)
            {
                int s = r.Next(0, 4);
                fsm.ChangeState((GameState)s);
            }
        }


    }

    class CombatSingleton
    {
        CombatSingleton()
        {

        }

        static readonly public CombatSingleton Instance = new CombatSingleton();
        
    }

    class Game
    {

    }
}
