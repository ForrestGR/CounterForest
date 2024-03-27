using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;

    public GameObject bulletPrefab;

    public Transform playerTransform;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        AimTowardsPlayer();

    }



    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


    void AimTowardsPlayer()
    {
        if (playerTransform != null)
        {
            // Berechnen Sie die Richtung weg vom Player
            Vector2 direction = firePoint.position - playerTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle);
        }

    }


}
