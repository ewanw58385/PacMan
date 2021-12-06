using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Stack<State> States {get; set;} //define new Stack

    private void Awake()
    {
        States = new Stack<State>(); //instantiate Stack
    }

    private State GetCurrentState()
    {
        return States.Count > 0 ? States.Peek() : null; //if there is at least one state in the stack, ".peek" - return the state highest in the stack (current state)
    }

    void Update()
    {
        if (GetCurrentState() != null) //if there is a state within the stack
        {
            GetCurrentState().ActiveAction.Invoke(); //return the current state        
        }
    }

    public void PushState(System.Action onEnter, System.Action active, System.Action onExit) //method for pushing new state to the top of the stack. 
    //Takes in the 3 state parameters for transitioning between states
    {
        if (GetCurrentState() != null) //if there is a state in the stack
        {
          GetCurrentState().OnExit(); //Exit the current state

          State state = new State(onEnter, active, onExit); //create a new state with the enter, current and exit parameters 
          States.Push(state); //adds new state tp the top of the stack
          GetCurrentState().OnEnter(); //execute the OnEnter method for new state 
        }
    }

public void PopState()
{
    if (GetCurrentState() != null) //if there is a state in stack
    {
        GetCurrentState().OnExit(); //Exit the current state
        GetCurrentState().ActiveAction = null; //delete the current state's active state
        States.Pop(); //remove top state from stack
        
        GetCurrentState().OnEnter(); //exceute the new current state's enter method (previous state in stack)
    }
}
    
}
