using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb; // Referenz auf unseren Rigidbody/unseren Player

    private Vector2 movement;
    private bool facingRight = true; //Startausrichtung des Charakters


    private void Start()
    {
        Flip();        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        // Den Charakter in Bewegungsrichtung ausrichten
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate() // Wird in einem festen Zeitintervall aufgerufen, unabh�ngig von der Bildwiederholrate
    {
        // Bewegung
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
        rb.velocity = movement * moveSpeed;
    }

    void Flip()
    {
        // Umkehren der Ausrichtung des Charakters
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public bool GetFacingRight()
    {
        return facingRight;
    }
}