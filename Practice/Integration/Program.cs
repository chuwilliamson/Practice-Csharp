using System;
using System.Diagnostics;
using Utilities;
using Utilities.Serialization;

namespace Integration
{
    public enum States
    {
        init = 0,
        idle = 1,
        exit = 2,
    }
   
    [Serializable]
    public class Unit
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Resource { get; set; }
    }
    class Program
    {
        public static readonly string savepath = Environment.CurrentDirectory + "../Saves/Json/";

        static void Test1()
        {

            Unit u = new Unit() { Health = 5, Name = "Max", Resource = 25, };
            XML.Save<Unit>("unit", u);
            Unit b = XML.Load<Unit>("unit");

        }

        static void Test2()
        {
            FiniteStateMachine<States> fsm = new FiniteStateMachine<States>();
            Action a = doit;
            fsm.AddTransition(States.init, States.idle, a);
            fsm.AddTransition(States.idle, States.idle, a);
            fsm.AddTransition(States.init, States.exit, a);
            
            
            fsm.Start(States.init);
            
            for(int i = 0; i < 25; i++)
                fsm.ChangeState(i % 3);
            Json.Save("gamefsminit100", fsm);
            
        }

        static void Main(string[] arguments)
        {
            Debug.WriteLine(string.Format("valid transition...\n"));
           
            Process.Start("Code", savepath + "gamefsminit100.json");
        }
        static void doit() { }


       


    }
}
