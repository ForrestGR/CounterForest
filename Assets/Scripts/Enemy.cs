using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;
    
    public GameObject deathEffect;
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the player


    private void Start()
    {
        currentHealth = maxHealth;
    }




    void Update()
    {
        FollowPlayer();
    }




    void FollowPlayer()
    {
        if (player == null) return; // Do nothing if the player reference is missing

        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }



    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
