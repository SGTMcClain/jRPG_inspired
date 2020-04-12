using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_End : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rigidbody2D = new Rigidbody2D();

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  
    }

    // Fixed Update is called at a fixed interval independently from the frame rate
    void FixedUpdate()
    {
        //Store the current horizontal input in the flot moveHorizontal
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the flot moveVertical
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two stored floats to create a new Vector2 vaiable called movement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //rigidbody2D.AddForce(movement * speed);
        rigidbody2D.velocity = movement * speed;
    }
}
