using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostState : MonoBehaviour //state script for dynamic animations
{
    private StateMachine brain;
    private Animator anim;

    private float changeMind;

    void Start () 
    {
        anim = GetComponent<Animator>();
        brain = GetComponent<StateMachine>();

        if (brain == null)
        {
            Debug.Log("No brain");
        }

        brain.PushState(OnChaseEnter, OnChaseActive, OnChaseExit); //first state to be pushed to stack (chasing player)
    }

    void OnChaseEnter() //chasing the player 
    {
        anim.SetBool("isBeingChased", false); //sets default animation
        Debug.Log("default state");
    }

    void OnChaseActive() //while chasing the player
    {
        if (GhostAi.runAway == true) //if powerup gets collected during chasing player (detecting collision every frame)
        {
            brain.PushState(OnBeingChasedEnter, OnBeingChasedActive, OnBeingChasedExit); //push "being chased" state to stack
        }
    }

    void OnChaseExit() //chasing the player
    {

    }

    ////////////////////////

    void OnBeingChasedEnter()
    {
        anim.SetBool("isBeingChased", true); //set being chased animation
        Debug.Log("being chased");

        changeMind = 15; //15 second timer where player can chase the ghosts 
        changeMind -= Time.deltaTime; //decrease timer in relation to deltaTime. 

        if (changeMind <= 0) //if timer reaches 0
        {
            brain.PushState(OnChaseEnter, OnChaseActive, OnChaseExit); //swap state to chasing player 
        }
    }

    void OnBeingChasedActive()
    {

    }

    void OnBeingChasedExit()
    {
        anim.SetBool("isBeingChased", false); //change animation back to default
        GhostAi.runAway = false; //set run away back to false on Exit

        changeMind = 0; //reset timer
    }
}
