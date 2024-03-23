using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Varibales
    public float moveSpeed = 5f;

    public Rigidbody2D rb;  //referenz to our rigidbody

    private Vector2 movement;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

    }


    private void FixedUpdate()        //called on a fixex timer, not on fps
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}


//random änderung

//another one