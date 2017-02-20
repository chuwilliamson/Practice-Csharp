using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Utilities
{
    [DataContract(Name = "Callback")]
    public class Callback
    {
        public Callback() { }

        [IgnoreDataMember]
        Action action;
        [DataMember(Name = "Method Name")]
        string method;

        /// <summary>
        /// name of the class instance on which the current delegate invokes the instance method
        /// </summary>
        [DataMember(Name = "Target Object")]
        string target;

        public void Invoke()
        {
            action.Invoke();
        }

        public void AddListener(Action a)
        {
            method = a.Method.ToString();
            target = (a.Target == null) ? "null" : a.Target.ToString();
            action += a;
        }

    }

    [DataContract(Name = "State")]
    public class State
    {
        public State() { }
        public State(string id)
        {
            Name = id;
            HashCode = GetHashCode();
        }

        [DataMember(Name = "State ID")]
        public int HashCode
        {
            get; set;
        } 
        [DataMember(Name = "State Name")]
        public string Name
        {
            get; set;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return 17 + 31 * Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == (obj as State).GetHashCode();
        }

        [IgnoreDataMember]
        public Action OnEnter;


        public void RegisterCallback(Action action)
        {
            OnEnter += action;
        }
    }

    [DataContract(Name = "Transition")]
    public class Transition
    {
        public Transition(State a, State b)
        {
            from = a;
            to = b;
            name = a.ToString() + "->" + b.ToString();
            OnTrigger = new Callback();
        }

        public override string ToString()
        {
            return (from.ToString() + "->" + to.ToString());
        }

        public override int GetHashCode()
        {
            return 17 + 31 * from.GetHashCode() + 31 * to.GetHashCode();
        }

        [DataMember]
        State from;

        [DataMember]
        State to;

        [DataMember(Name = "Transition Name")]
        string name;

        //[DataMember(Name = "Callback")]
        [IgnoreDataMember] // we can come back to this later
        public Callback OnTrigger;

        public void Execute()
        {
            OnTrigger.Invoke();
        }



    }

    [DataContract(Name = "State Machine")]
    public class FiniteStateMachine<T> where T : struct
    {
        /// <summary>
        /// Create fsm and with enums
        /// </summary>
        public FiniteStateMachine()
        {
            states = new Dictionary<string, State>();
            transitions = new Dictionary<string, Transition>();
            var vals = Enum.GetValues(typeof(T));
            Log = new List<string>();
            foreach(var v in vals)
            {
                string name = v.ToString();
                states.Add(name, new State(name));
                Log.Add(string.Format("added state:: {0} @ {1}", name, DateTime.Now.ToString()));
            }
            
        }

        [DataMember(Name = "State Machine Log")]
        public List<string> Log
        { get; set; }

        [DataMember(Name = "Current State")]
        public State current;

        [DataMember(Name = "States")]
        Dictionary<string, State> states;


        [DataMember(Name = "Transitions")]
        Dictionary<string, Transition> transitions;

        /// <summary>
        /// add transition with a callback for the exit of state a and enter of state b
        /// </summary>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        /// <param name="enter">to onenter</param>        
        public void AddTransition(T from, T to, Action enter)
        {
            var s1 = (from as Enum).ToString();
            var s2 = (to as Enum).ToString();
            Transition t = new Transition(states[s1], states[s2]);
            t.OnTrigger.AddListener(enter);
            transitions.Add(t.ToString(), t);
        }

        /// <summary>
        /// start machine with enum
        /// </summary>
        /// <param name="a"></param>
        public void Start(T a)
        {
            var s1 = (a as Enum).ToString();
            current = states[s1];
            Log.Add(string.Format("start machine!!! \n"));
        }
        
        /// <summary>
        /// update the fsm
        /// </summary>
        /// <returns>true if fsm can update</returns>
        public bool Update()
        {
            return true;
        }
        
        public bool ChangeState(int id)
        {            
            var enums = Enum.GetValues(typeof(T));
            var e = enums.GetValue(id);
            var s1 = current.Name;
            var s2 = e.ToString();
            var s3 = s1 + "->" + s2;
            if(transitions.ContainsKey(s3))
            {
                Log.Add(string.Format("valid transition...{0} \n", s3)) ;
                
                current = states[s2];
                transitions[s3].Execute();
                return true;
            }
            Log.Add(string.Format("invalid transition...{0} \n", s3));
            return false;            
        }


        /// <summary>
        /// Change state of machine
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool ChangeState(T to)
        {
            var s1 = current.Name;
            var s2 = (to as Enum).ToString();
            var s3 = s1 + "->" + s2;
            if(transitions.ContainsKey(s3))
            {
                Log.Add(string.Format("valid transition...{0} \n", s3));
                current = states[s2];
                transitions[s3].Execute();
                return true;
            }
            Log.Add(string.Format("invalid transition...{0} \n", s3));
            return false;
        }


    }

}
