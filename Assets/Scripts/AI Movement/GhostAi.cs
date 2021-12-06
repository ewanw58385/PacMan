using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAi : MonoBehaviour //Ai script for NatMesh movement 
{
    //public Transform[] points;
    public List<GameObject> points = new List<GameObject>(); //new list
    private int listLength; //int for list length

    private NavMeshAgent nav;
    private int destPoint;

    private Rigidbody rb;
    private Vector3 movement;

    public static bool runAway = false; //static bool so can be accessed from GhostState script
    public GameObject playerRunAway;

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
        //print(points[0].transform.position); //print point location
    }

    void GoToNextPoint()
    {
        if (listLength == 0) //if no points to travel to
        {
            return;
        }

        if (!runAway) //if not running away from player 
        {
            nav.destination = points[destPoint].transform.position; //travel to destination (player)
            destPoint = (destPoint + 1) % listLength; //sets next destiation
        }

        if (runAway) //if running away from player
        {
            Vector3 directionToplayer = transform.position - playerRunAway.transform.position; //calculates the directon to player in opposite direction
            Vector3 newPostion = transform.position + directionToplayer; //new position for AI to move to

            nav.SetDestination(newPostion); //move to new position (away from player)
        }
    }
}
