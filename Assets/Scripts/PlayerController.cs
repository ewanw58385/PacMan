using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public GameObject nextPoint;
    public static List<GameObject> gameObjectsList = new List<GameObject>(); //create list of gameObjects (static so Ai script can access)
    //this is done because AI follow a moving player and they don't dymanically update the position until point is reached

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("CallPointsMaker", 1f, 0.1f); //create point for AI to follow 
    }


    void FixedUpdate()
    {
        MovePlayer();
    }

    void CallPointsMaker() //because you can't invoke a method that passes a parameter 
    {
        CreatePointsForAI(gameObjectsList);
    }

    void CreatePointsForAI(List<GameObject> GoList) //takes list of gameObjects 
    {
        GameObject emptyInstantiated = Instantiate(nextPoint, gameObject.transform.position, Quaternion.identity); 
        //instantiates point at player's position
        GoList.Add(emptyInstantiated); 
        //adds positon to array 

        if (GoList.Count > 1) //if the List contains more than 1 element (so initial element isn't destroyed)
        {
            GameObject.Destroy(GoList[0]); //destroy gameObject at position 0 so List always has only 1 gameObject that changes position   
            GoList.RemoveAt(0); //remove element from the list 
        }

        //print(GoList[0].transform.position);
    }

        void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            print("hit!");
            Destroy(gameObject);
        }
    }

    void MovePlayer()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) )
        {
            rb.velocity = Vector3.forward * speed;
        }

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) )
        {
            rb.velocity = Vector3.back * speed;
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) )
        {
            rb.velocity = Vector3.left * speed;
        }
        
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) )
        {
            rb.velocity = Vector3.right * speed;
        }

        if (!Input.anyKey)
        {
            rb.velocity = new Vector3 (0, 0, 0);
        }
    }
}
