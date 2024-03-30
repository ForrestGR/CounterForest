using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Enemy enemy;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        healthBar.SetHealth(currentHealth);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(40);
        }
    }



    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

}
