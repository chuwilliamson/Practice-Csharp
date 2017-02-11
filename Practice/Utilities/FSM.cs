using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Assessment_4
{ public enum HandlerOrder
        {
            ONENTER,
            ONEXIT,
        }
    public class State
    {
        //CLASS 'STATE' MEMBER VARIABLE(S)
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Enum StateName;

        //DEFAULT CONSTRUCTOR
        //  - NEEDS WORK
        public State()
        {
        }

        //STATE CONSTRUCTOR
        //  - ASSIGNS THE PASSED IN ENUM 'E' TYPEDCASED AS A STRING
        //      - 'e.ToString()'
        //  - TO THE STATE MEMBER VARIABLE 'NAME'
        public State(Enum e)
        {
            this.name = e.ToString();
            this.StateName = e;
        }

        //ONENTER() DELEGATE
        //  - AFTER TRANSITION, INVOKE ALL FUNCTIONS INSIDE OF DELEGATE 'ONENTER' 
        //  - WHEN ENTERING ANOTHER STATE        
        public Action onEnter = null;

        //ONEXIT() DELEGATE
        //  - AFTER TRANSITION, INVOKE ALL FUNCTIONS INSIDE OF DELEGATE 'ONEXIT' 
        //  - WHEN LEAVING ANOTHER STATE        
        public Action onExit = null;

        //FUNCTION 'ADDENTERFUNCTION()'
        //  - ADDS A FUNCTION OF SAME TYPE AND ARGUMENT LIST TO DELEGATE 'ONENTER'
        public void AddEnterFunction(Delegate del)
        {
            //TYPECAST DELEGATE 'DEL' WITH THE DELEGATE TYPE 'STATEMANAGER'
            //  - ADD TYPECAST DELEGATE 'DEL' TO MEMBER DELEGATE ONENTER
            //  - LEARN MORE..
            //  - 01-27-17 LEARN HOW TO SPELL..
            //var cb = del as StateManager;            
            this.onEnter += del as Action;
        }

        //FUNCTION 'ADDEXITFUNCTION()'
        //  - ADDS A FUNCTION OF SAME TYPE AND ARGUMENT LIST TO DELEGATE 'ONEXIT'
        public void AddExitFunction(Delegate del)
        {
            //TYPECAST DELEGATE 'DEL' WITH DELEGATE TYPE 'STATEMANAGER'
            //  - ADD TYPECAST DELEGATE 'DEL' TO MEMEBER DELEGATE ONEXIT
            this.onExit += del as Action;
        }

    }

    /// <summary>
    /// FINITE STATE MACHINE
    /// </summary>
    /// <typeparam name="T">enum of states</typeparam>
    public class FSM<T>
    {
       

        
        //INSTANCE OF CLASS 'STATE'
        //  - HOLDS THE CURRENT 'STATE' OF THE APPLICATION
        private State currentState;

        //INSTANCE OF CLASS 'DICTIONARY' NAMED 'STATES'
        //KEY = STRING
        //VALUE = STATE
        private Dictionary<string, State> states;

        //INSTANCE OF CLASS 'DICTIONARY' NAMED 'TRANSITIONS'
        //  - KEY = STRING
        //  - VALUE = LIST<STATE>
        private Dictionary<string, List<State>> transitions;

        //DEFAULT CONSTRUCTOR
        public FSM()
        {
            //INITILIZE MEMBER VARIABLES HERE?
            //01-26-17 YES 
            //  - WHEN CLASS 'FSM()' IS CONSTRUCTED DICTIONARY 'STATES' GET POPULATED
            //01-27-17
            //  - INITILIZE DICTIONARY 'TRANSITIONS'
            this.transitions = new Dictionary<string, List<State>>();

            //INITILIZE DICTIONARY 'STATES'
            this.states = new Dictionary<string, State>();

            //ASSIGN VAR 'V' THE LIST OF ENUMS
            //  - USE 'TYPEOF(T)' 
            //      - USED FOR DIFFERENT STATES
            var enumList = Enum.GetValues(typeof(T));

            //ITERATE THROUGH 'ENUMLIST'
            //  - CREATE A NEW STATE, TYPECAST 'FSM_ENUM' WITH TYPE ENUM
            //  - ADD EACH NEW STATE TO DICTIONARY 'STATES'
            //  - WITH THE CORRECT KEY AND VALUE '<STRING, STATE()>'
            foreach(var fsm_enum in enumList)
            {
                State s = new State(fsm_enum as Enum);
                this.states.Add(s.Name, s);
            }

        }

        //ADDSTATE() FUNCTION
        //  - CHECKS IF THE STATE BEING ADDED EXISTS IN DICTIONARY 'TRANSITIONS'
        public bool AddState(State state)
        {
            //ACCESS INSTANCE OF DICTIONARY CLASS NAMED 'TRANSITIIONS'
            //  - CHECK IF DICTIONARY 'TRANSITIONS' == NULL
            //  - CHECK IF STATE ALREADY EXISTS
            if(this.transitions[state.Name] == null)
            {
                //IF STATE DOES NOT EXITS IN DICTIONARY 'TRANSITIONS'
                //  - ADD THE STATE'S NAME AND A NEW LIST OF STATES TO THE DICTIONARY
                this.transitions.Add(state.Name, new List<State>());

                //RETURN TRUE IF SUCCESSFUL
                return true;
            }

            //IF STATE ALREADY EXISTS IN DICTIONARY 'TRANSITIONS'
            //  - RETURN FALSE
            return false;
        }

        //ISVALIDTRANSITION() FUNCTION
        //RETURNS TRUE IF STATE 'TO' IS IN THE TRANSITION DICTIONARY
        //IF STATE 'TO' IS NOT IN THE TRANSITION DICTIONARY
        //  - RETURN FALSE
        private bool isValidTransition(State to)
        {

            //VAR 'VALIDSTATES' IS ASSIGNED THE LIST OF STATES CURRENTSTATE CAN GO TO?
            var validStates = this.transitions[this.currentState.Name];

            //CHECK IF LIST 'VALIDSTATES' == NULL
            //IF TRUE, RETURN FALSE
            if(validStates == null)
            {
                return false;
            }

            //ITERATE THROUGH LIST 'VALIDSTATES'
            //  - CHECK IF STATE 'TO' EXISTS IN 'VALIDSTATES'
            foreach(var state in validStates)
            {
                if(state == to)
                {
                    return true;
                }
            }

            //IF STATE 'TO' DOES NOT EXIST IN 'VALIDSTATES'
            //RETURN FALSE
            return false;
        }
        public bool AddStateFunction(HandlerOrder delegateName, T state, Delegate del)
        {
            
            //IF STRING 'FUNCNAME' != 'ONENTER' OR != 'ONEXIT'
            //  - RETURN FALSE
         

            //STRING 'STATEKEY'
            //  - TYPECAST TEMPLATED VARIABLE 'STATE' AS AN ENUM, INVOKE THE OBJECT METHOD FUNCTION '.TOSTRING()' TO CONVERT ENUM TO STRING
            //  - USED AS THE INDEXER FOR DICTIONARY 'STATES'
            string stateKey = (state as Enum).ToString();

            //IF STRING 'FUNCNAME' == 'ONENTER'
            //  - ACCESS DICTIONARY 'STATES'
            //  - INVOKE 'ADDENTERFUNCTION()' FROM THE STATE AT THE INDEX OF 'STATEKEY'
            //  - PASS IN DELEGATE 'D' AS THE ARGUMENT FOR 'ADDENTERFUNCTION()'
            //  - RETURN TRUE
            if(delegateName.ToString() == "ONENTER")
            {
                this.states[stateKey].AddEnterFunction(del);
                return true;
            }

            //IF STRING 'FUNCNAME' == 'ONEXIT'
            //  - ACCESS DICTIONARY 'STATES'
            //  - INVOKE 'ADDEXITFUNCTION()' FROM THE STATE AT THE INDEX OF 'STATEKEY'
            //  - PASS IN DELEGATE 'DEL' AS THE ARGUMENT FOR 'ADDEXITFUNCTION()'
            //  - RETURN TRUE
            if(delegateName.ToString() == "ONEXIT")
            {
                this.states[stateKey].AddExitFunction(del);
                return true;
            }

            //IF ERROR, RETURN FALSE
            return false;
        }
        //ADDSTATEFUNCTION() FUNCTION
        //  - ADDS A FUNCTION TO A STATE'S 'ONENTER' OR 'ONEXIT' DELEGATE
        //  - NEEDS WORK
        public bool AddStateFunction(string delegateName, T state, Delegate del)
        {
            delegateName = delegateName.ToUpper();
            //IF STRING 'FUNCNAME' != 'ONENTER' OR != 'ONEXIT'
            //  - RETURN FALSE
            if(delegateName != "ONENTER" && delegateName != "ONEXIT" && delegateName != "COMBATENTER" && delegateName != "COMBATEXIT")
            {
                return false;
            }

            //STRING 'STATEKEY'
            //  - TYPECAST TEMPLATED VARIABLE 'STATE' AS AN ENUM, INVOKE THE OBJECT METHOD FUNCTION '.TOSTRING()' TO CONVERT ENUM TO STRING
            //  - USED AS THE INDEXER FOR DICTIONARY 'STATES'
            string stateKey = (state as Enum).ToString();

            //IF STRING 'FUNCNAME' == 'ONENTER'
            //  - ACCESS DICTIONARY 'STATES'
            //  - INVOKE 'ADDENTERFUNCTION()' FROM THE STATE AT THE INDEX OF 'STATEKEY'
            //  - PASS IN DELEGATE 'D' AS THE ARGUMENT FOR 'ADDENTERFUNCTION()'
            //  - RETURN TRUE
            if(delegateName == "ONENTER")
            {
                this.states[stateKey].AddEnterFunction(del);
                return true;
            }

            //IF STRING 'FUNCNAME' == 'ONEXIT'
            //  - ACCESS DICTIONARY 'STATES'
            //  - INVOKE 'ADDEXITFUNCTION()' FROM THE STATE AT THE INDEX OF 'STATEKEY'
            //  - PASS IN DELEGATE 'DEL' AS THE ARGUMENT FOR 'ADDEXITFUNCTION()'
            //  - RETURN TRUE
            if(delegateName == "ONEXIT")
            {
                this.states[stateKey].AddExitFunction(del);
                return true;
            }

            //IF ERROR, RETURN FALSE
            return false;
        }

        //GETSTATE() FUNCTION
        //  - RETURNS THE CURRENT STATE IN THE DICTIONARY 'STATES'
        public State getState(T e)
        {
            //TYPECASE 'e' AS A STATE
            //  - ASSIGN STRING 'KEY' THE VALUE '.NAME'
            string key = (e as State).Name;

            //RETURN THE STATE THAT IS ASSIGNED TO 'KEY'
            //  - 'states[key]'
            //      - RETURNS A STATE
            return this.states[key];
        }

        //GETCURRENTSTATE() FUNCTION
        //  - RETURNS THE CURRENT STATE 
        public State getCurrentState()
        {
            return this.currentState;
        }


        //CHANGESTATE() FUNCTION
        //  - CHECKS IF STATE 'CURRENTSTATE' -> STATE 'STATETO' IS A VALID TRANSITION
        //  - INVOKES STATE 'CURRENTSTATE'S 'ONEXIT' DELEGATE
        //  - ASSIGNS STATE 'CURRENTSTATE' WITH THE STATE 'STATETO'
        //  - INVOKES STATE 'CURRENTSTATE'S 'ONENTER' DELEGATE
        //  - NEEDS WORK
        public void ChangeState(State stateTo)
        {

            //STRING 'STATEKEY' IS ASSIGNED THE CURRENT STATE + "->" + 'STATETO'
            string stateKey = this.currentState.Name + "->" + stateTo.Name;

            //CHECK IF STATE 'STATETO' IS A VALID TRANSITION FROM MEMEBER VARIABLE 'CURRENTSTATE'
            //  - INVOKE DICTIONARY 'TRANSITIONS' MEMBER FUNCTION 'CONTAINSKEY'
            //  - 'STATEKEY' IS PASSED IN AS THE ARGUMENT, RETURNS A BOOLEAN VARIABLE (TRUE/FALSE)
            //  - IF TRUE, INVOKE STATE 'CURRENTSTATE'S 'ONEXIT' DELEGATE
            //  - ASSIGN STATE 'STATETO' TO STATE 'CURRENTSTATE'
            //  - INVOKE 'CURRENTSTATE'S 'ONENTER' DELEGATE
            if(this.transitions.ContainsKey(stateKey))
            {
                this.currentState.onExit.Invoke();
                this.currentState = this.states[stateTo.Name];
                this.currentState.onEnter.Invoke();
            }
        }

        //ADDTRANSITION<V>() FUNCTION
        //  - NEEDS WORK
        public bool AddTransition(T stateFrom, T stateTo)
        {
            //STRING 'TRANSITIONKEY'
            //  - TYPECASTS 'STATEFROM' AND 'STATETO' AS AN ENUM, OBJECT METHOD FUNCTION 'TOSTRING()' IS INVOKED
            //  - USE OF STRING '->' FOR CONVENCTION AS DICTACTED BY INSTRUCTOR
            //string transitionKey = (stateFrom as State).name + "->" + (stateTo as State).name;
            string transitionKey = new State(stateFrom as Enum).Name + "->" + new State(stateTo as Enum).Name;



            //CHECK IF DICTIONARY 'TRANSITIONS' != NULL
            //  - IF TRUE, ADD STRING 'TRANSITIONKEY' AS DICTIONARY 'TRANSITIONS'S KEY
            //      - ADD LIST 'TRANSITION' AS DICTIONARY 'TRANSITIONS'S VALUE
            if(this.transitions.ContainsKey(transitionKey) == false)
            {
                //LIST<STATE> 'TRANSITION'
                //  - CREATES A NEW LIST NAMED 'TRANSITION'
                //  - ADDS 'STATEFROM' AND 'STATETO' TYPECASTED AS AN STATE TO LIST 'TRANSITION'
                //  -RESEARCH TUPLE
                List<State> Transition = new List<State>();
                string fromName = (stateFrom as Enum).ToString();
                string toName = (stateTo as Enum).ToString();
                Transition.Add(states[fromName]);
                Transition.Add(states[toName]);
                this.transitions.Add(transitionKey, Transition);
                return true;
            }

            return false;
        }

        //INITILIZEMANAGER() FUNCTION
        //  - INITILIZE ALL ASSETS
        //  - NEEDS WORK
        public bool InitilizeManager()
        {
            //MEMEBER DICTIONARYS ARE INITILIZE WITHIN THE CLASS CONSTRUCTOR
            //  - IMPLEMENT INTILIZATION OF DICTIONARY 'TRANSITIONS'S STATE DELEGATES


            return true;
        }
    
        //'STARTMANAGER()' FUNCTION
        //  - STARTS UP THE FINITE STATE MACHINE
        //  - NEEDS WORK
        public void StartMachine(State startState)
        {
            if(this.states.ContainsKey(startState.Name))
            {
                //ASSIGN MEMEBER VARIABLE 'CURRENTSTATE' WITH THE STATE FROM MEMEBER DICTIONARY 'STATES'
                this.currentState = this.states[startState.Name];
                //INVOKE MEMEBER VARIABLE 'CURRENTSTATE' DELEGATE 'ONENTER'
                this.currentState.onEnter.Invoke();

                //UPDATE THE FSM
                //this.UpdateManager();
            }
        }

        //UPDATE() FUNCTION
        //  - UPDATES THE 'UI' PER LOOP
        //  - NEEDS WORK
        public bool UpdateManager()
        {
            //CLEAR THE SCREEN ON EVERY LOOP
            //Console.Clear();

            //CHECK WHAT VARIABLE 'CONDITION' IS
            //  - INVOKE METHOD 'CHANGESTATE' IF NESSASSARY

            //DISPLAY TO CONSOLE THAT THE FSM HAS UPDATED (DEBUG)
            Console.WriteLine("FSM<" + currentState.ToString() + "> UPDATE");
            return true;
        }

        //RUN() FUNCTION
        //  - MAIN APP LOOP
        //  - NEEDS WORK
        //  - MORE USEFUL WHEN PORTED TO 'WINDOWSFORMS'
        //  - NOT NEEDED????
        public bool RunManager()
        {
            //APPLICATION LOOP?
            //INVOKE CHANGESTATE() HERE????
            return true;
        }
    }
}