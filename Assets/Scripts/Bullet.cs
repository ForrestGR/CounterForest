using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 20f;
    public int damage = 40;

    public Rigidbody2D rb;

    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }


        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}