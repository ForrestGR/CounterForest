using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public Rigidbody2D rb;

    private PlayerMovement playerMovement;



    private void Start()
    {
        // Stelle sicher, dass du eine Referenz zum PlayerMovement-Skript hast,
        // das am Spieler-GameObject angebracht ist.
        playerMovement = playerTransform.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        AimDirection();

        Debug.Log(rb.velocity);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void AimDirection()
    {
        if (rb != null)
        {
            // Verwende die aktuelle Geschwindigkeit des Spielers, um die Richtung zu bestimmen
            Vector2 direction = rb.velocity;
            if (direction != Vector2.zero) // Pr�fe, ob der Spieler sich bewegt
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                firePoint.rotation = Quaternion.Euler(0, 0, angle);
            } 
            else
            {
                if (playerMovement.GetFacingRight() == true)
                {
                    firePoint.right = Vector2.right;
                }
                else 
                {
                    firePoint.right = Vector2.left;
                }
            }
        }
    }
}
