using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
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
            rb.velocity = Vector3.left* speed;
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
