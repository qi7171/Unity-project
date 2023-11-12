using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HittingObject : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the objects you want to disappear
        if (collision.gameObject.CompareTag("Target"))
        {
            // Disable the collider of the collided ball
            GetComponent<Collider>().enabled = false;



            // Remove the collided ball from the scene
            Destroy(gameObject);
        }
    }
}
