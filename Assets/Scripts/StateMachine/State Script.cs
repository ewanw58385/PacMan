using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateScript
{

    public Action ActiveAction; //Action is a way to define a delegate (which is a variable which represents/ points to a method with specific parameter types)
    public Action OnEnterAction;
    public Action OnExitAction;

    public void State (Action active, Action onEnter, Action onExit) //Create constructor which uses methods (actions) as parameters.  We then assign these methods to variables of the same type. 
    {
        ActiveAction = active;
        OnEnterAction = onEnter;
        OnExitAction = onExit;
    }

    public void Execute() //Create three methods to be called when we use/ transition a state. Execute, OnEnter and OnExit states. 
    {
        if (ActiveAction != null) //if statement to ensure Action variable is assigned to a method. 
        {
            ActiveAction.Invoke();  //exceute method (action)
        }
    }

    public void OnEnter()
    {
        if (OnEnterAction != null)
        {
            OnEnterAction.Invoke();
        }
    }

    public void OnExit()
    {
        if (OnExitAction != null)
        {
            OnExitAction.Invoke();
        }
    }

}
