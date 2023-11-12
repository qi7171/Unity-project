using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DisappearOnCollision : MonoBehaviour
{
    public ObjectGenerator objectGenerator; // Reference to the ObjectGenerator script
    //-----------------------------------------------------------------------------
    public List<GameObject> ivyObjects;
    private int nextIvyIndex = 0; // Index of the next Ivy object to hide


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the hitting object
        /* if (collision.gameObject.CompareTag("HittingObject"))
         {
             // Hide the object
             gameObject.SetActive(false);

             // Generate a new object after a delay
             Invoke("GenerateNewObject", 1f);

         }*/
        if (collision.gameObject.CompareTag("HittingObject") && objectGenerator.IsNewObject)
        {
            // Set the flag to true to prevent multiple hits
            // hasBeenHit = true;

            // Hide the object
            gameObject.SetActive(false);

            //-----------------------------------------------------------------------------

            // Hide the next Ivy object in the sequence
            if (ivyObjects.Count > 0)
            {
                GameObject ivyObject = ivyObjects[nextIvyIndex];
                ivyObject.SetActive(false);

                // Increment the index for the next Ivy object
                nextIvyIndex = (nextIvyIndex + 1) % ivyObjects.Count;
            }
            //-----------------------------------------------------------------------------

            // Generate a new object
            //objectGenerator.GenerateNewObject();
            // Generate a new object after a delay
            Invoke("GenerateNewObject", 1f);

            // Increment the counter
            objectGenerator.UpdateCountText();
            // Set IsNewObject to false for the original object
            objectGenerator.IsNewObject = false;
        }
    }

    private void GenerateNewObject()
    {
        // Show the object
        gameObject.SetActive(true);

        // Generate a new object using the ObjectGenerator script
        objectGenerator.GenerateNewObject();
    }
}