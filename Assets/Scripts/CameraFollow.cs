using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public float yOffset = .1f;
    public Transform target;

    public float minX = 0f; // Minimale X-Position
    public float maxX = 5f; // Maximale X-Position
    public float minY = 0f; // Minimale Y-Position
    public float maxY = 5f; // Maximale Y-Position



    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);


        // Begrenzen der neuen Position innerhalb der festgelegten Min/Max Grenzen
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);


        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
