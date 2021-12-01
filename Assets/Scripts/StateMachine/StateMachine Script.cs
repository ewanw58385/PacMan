using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{

    public Stack<State> States {get; set;} //define new Stack

    private void Awake()
    {
        States = new Stack<State>(); //instantiate Stack
    }

    private State GetCurrentState()
    {
        return States.Count > 0 ? States.Peek() : null;
    }
}
