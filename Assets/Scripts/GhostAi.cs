using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAi : MonoBehaviour
{
    //public Transform[] points;
    public List<GameObject> points = new List<GameObject>(); //new list
    private int listLength; //int for list length

    private NavMeshAgent nav;
    private int destPoint;

    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        points = PlayerController.gameObjectsList; //set list as the list from AiPoint Instantiation method from player controller
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        listLength = points.Count;

         if (points.Count > 1) //if the List contains more than 1 element (so initial element isn't destroyed)
        {
            GameObject.Destroy(points[0]); //destroy gameObject at position 0 so List always has only 1 gameObject that changes position   
            points.RemoveAt(0); //remove element from the list 
        }

        if (!nav.pathPending && nav.remainingDistance < 0.5f) //check if has reached destination
        {
  	        GoToNextPoint();
        }

        DisableDiagonalMovement();

        //print(points[0].transform.position); //print point location
    }

    void GoToNextPoint()
    {
        if (listLength == 0) //if no points to travel to
        {
            return;
        }
        nav.destination = points[destPoint].transform.position; //travel to destination
        destPoint = (destPoint + 1) % listLength; //sets next destiation
    }

    void DisableDiagonalMovement()
    {
        movement.x = rb.velocity.x;
        movement.z = rb.velocity.z;

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.z)) //if statement disables diagonal movement
        {
            movement.z = 0;
        }
        else
        {
            movement.x = 0;
        }
    }
}
