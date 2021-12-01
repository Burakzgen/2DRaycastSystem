using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedCharacterRotate, distanceRaycast;
    void Update()
    {
        transform.Rotate(Vector3.forward * speedCharacterRotate * Time.deltaTime); // Rotate object around
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distanceRaycast); // Required steps for raycast formation

        if (hit.collider != null) // Control of created raycast
        {
            //Debug.Log("Collision");
            Debug.DrawLine(transform.position, hit.point, Color.red); // Ray drawing on stage

            if (hit.collider.CompareTag("Player"))
            {
                Destroy(hit.collider.gameObject); //It should be noted that the objects have colliders
            }
        }
        else
        {
            //Debug.Log("Null");
            Debug.DrawLine(transform.position, transform.position + transform.right * distanceRaycast, Color.yellow);
        }
    }
}
