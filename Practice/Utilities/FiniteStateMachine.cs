using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Utilities
{ 
  
    public class State
    {
        public State(string id)
        {
            Name = id;
        }
        public override string ToString()
        {
            return Name;
        }
        public string Name
        {
            get; set;
        }
        public Action onEnter;
    }

    public class Transition
    {
        public Transition(State a, State b)
        {
            from = a;
            to = b;
            name = a.ToString() + "->" + b.ToString();
        }
        public override string ToString()
        {
            return (from.ToString() + "->" + to.ToString());
        }

        State from, to;
        public Action onTrigger;
        string name;
    }
    public class FiniteStateMachine<T>
    {
        public FiniteStateMachine()
        {
            states = new Dictionary<string, State>();
            transitions = new Dictionary<string, Transition>();
            var vals = Enum.GetValues(typeof(T));
            foreach(var v in vals)
            {
                string name = v.ToString();
                states.Add(name, new State(name));
            }
        }

        /// <summary>
        /// add transition with a callback for the exit of state a and enter of state b
        /// </summary>
        /// <param name="a">from</param>
        /// <param name="b">to</param>
        /// <param name="enter">to onenter</param>        
        public void AddTransition(T a, T b, Action enter)
        {
            var s1 = (a as Enum).ToString();
            var s2 = (b as Enum).ToString();
            Transition t = new Transition(states[s1], states[s2]);
            t.onTrigger += enter;
            transitions.Add(t.ToString(), t);
        }


        public void Start(T a)
        {
            var s1 = (a as Enum).ToString();
            current = states[s1];
            Debug.WriteLine("start machine");
        }
        public bool Update()
        {
            return true;
        }
        public bool ChangeState(T a)
        {
            var s1 = current.Name;
            var s2 = (a as Enum).ToString();
            var s3 = s1 + "->" + s2;
            if(transitions.ContainsKey(s3))
            {
                Debug.WriteLine("valid transition...{0}", s3, Environment.NewLine);
                current = states[s2];
                transitions[s3].onTrigger.Invoke();
                return true;
            }            
            Debug.WriteLine("invalid transition...{0}", s3, Environment.NewLine);
            return false;
        }

        State current;
        Dictionary<string, State> states;
        Dictionary<string, Transition> transitions;
    }

}
