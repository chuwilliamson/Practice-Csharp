using System;
using System.Collections.Generic;

namespace Combat.Utilities
{
    delegate void Handler();
    class State
    {
        public State(string id)
        {
            name = id;
        }
        public override string ToString()
        {
            return name;
        }
        string name;
        Handler onEnter;
        Handler onExit;
    }

    class Transition
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
        State from;
        State to;
        string name;
    }
    class FiniteStateMachine<T>
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
        public void AddTransition(T a, T b)
        {            
            var s1 = (a as Enum).ToString();
            var s2 = (b as Enum).ToString();
            Transition t = new Transition(states[s1],states[s2]);
            transitions.Add(t.ToString(), t);  
        }

        
        public void Start(T a)
        {
         
        }
        Dictionary<string, State> states;
        Dictionary<string, Transition> transitions;
    }
}


 var anvp = {}; anvp.p0 = {};anvp.p0.config = {"hashPrefix":"kjc15swt6h6nv","hashBaseUrl":"","referrerURL":"https://www.facebook.com/","parentPageURL":"http://klfy.com/2017/01/25/11th-annual-gumbo-cook-off-in-opelousas-to-benefit-toddler-with-medical-needs/","parentTitle":"11th Annual Gumbo Cook-off in Opelousas to benefit toddler with medical needs | KLFY","baseURL":"http://up.anv.bz/latest/kjc15swt6h6nv/","shareLink":"http://klfy.com/2017/01/25/11th-annual-gumbo-cook-off-in-opelousas-to-benefit-toddler-with-medical-needs/"};