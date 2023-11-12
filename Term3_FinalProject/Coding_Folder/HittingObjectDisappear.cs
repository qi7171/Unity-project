using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class HittingObjectDisappear : MonoBehaviour
{
    public BallGenerator ballGenerator; // Reference to the ObjectGenerator script
                                        //private bool hasBeenHit = false; // Flag to track if the object has been hit


     private void OnCollisionEnter(Collision collision)
     {

         if (collision.gameObject.CompareTag("Target") && ballGenerator.IsNewObject)
         {
             // Set the flag to true to prevent multiple hits
             // hasBeenHit = true;

             // Hide the object
             gameObject.SetActive(false);

             // Generate a new object
             //objectGenerator.GenerateNewObject();
             // Generate a new object after a delay
             Invoke("GenerateNewObject", 1f);


             // Set IsNewObject to false for the original object
             ballGenerator.IsNewObject = false;
         }
     }

     private void GenerateNewObject()
     {
         // Show the object
         gameObject.SetActive(true);

         // Generate a new object using the ObjectGenerator script
         ballGenerator.GenerateNewObject();
     }*/
//----------------------------
/*public class HittingObjectDisappear : MonoBehaviour
    {
        public BallGenerator ballGenerator;

        public GameObject previousObject; // Reference to the previous object

    private void OnCollisionEnter(Collision collision)
    {

            if (collision.gameObject.CompareTag("Target") && collision.gameObject.GetComponent<Rigidbody>()|| collision.gameObject.CompareTag("Sheild") && collision.gameObject.GetComponent<MeshCollider>() != null)
            {
                // Disable the collider of the collided ball
                GetComponent<Collider>().enabled = false;

                // Remove the collided ball from the scene
                Destroy(gameObject);
            }
        }


}*/
using TMPro;

public class HittingObjectDisappear : MonoBehaviour
{
    public BallGenerator ballGenerator;
    public ObjectGenerator objectGenerator;
    public TextMeshProUGUI remainingBallAmountText;


    //-----------------------------------NE 1.0 6.4
    public GameObject hitSheild; // Reference to the HitSheild game object
    public GameObject hitTarget; // Reference to the HitTarget game object

    private bool hitTargetActive = false;
    private bool hitSheildActive = false;
    //---------------------------------------------------

    //-----------------------------------NE 1.0 6.4
    private void Start()
    {
        // Hide the HitSheild and HitTarget game objects initially
        hitSheild.SetActive(false);
        hitTarget.SetActive(false);

    }
    //-----------------------------------

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Target") && collision.gameObject.GetComponent<Rigidbody>())
        {
            //-----------------------------------NE 1.0 6.4
            // Show the HitSheild game object
           if(!hitTargetActive)
            {
                hitTarget.SetActive(true);
                hitTargetActive = true;
                hitSheildActive = false;
                hitSheild.SetActive(false);

                //--------------------------------------------------
                // Play the hit sound
               
            }
           
            //----------------------------------------------

            ballGenerator.DecrementBallCount();
            objectGenerator.DecrementTargetAmount();
            UpdateRemainingBallAmountText();
            // Disable the collider of the collided ball
            GetComponent<Collider>().enabled = false;//--------------------------------
            Destroy(gameObject);//--------------


            


        }
        else if (collision.gameObject.CompareTag("Sheild") && collision.gameObject.GetComponent<MeshCollider>() != null)
        {

            //-----------------------------------NE 1.0 6.4
            // Show the HitTarget game object
            if (!hitSheildActive)
            {
                // Show the HitSheild game object
                hitSheild.SetActive(true);
                hitSheildActive = true;
                hitTargetActive = false;
                hitTarget.SetActive(false);
               
            }

            //--------------------------------------------------

            ballGenerator.DecrementBallCount();
            UpdateRemainingBallAmountText();
            GetComponent<Collider>().enabled = false;//--------------------------------
            Destroy(gameObject);//--------------

           
        }else
        {
            hitTarget.SetActive(false);
            hitSheild.SetActive(false);
        }
        // Disable the collider of the collided ball
       // GetComponent<Collider>().enabled = false;//--------------------------------

        // Remove the collided ball from the scene
       // Destroy(gameObject);//-----------------------
    }

    private void UpdateRemainingBallAmountText()
    {
        if (remainingBallAmountText != null && ballGenerator != null)
        {
            int remainingBallCount = ballGenerator.GetRemainingBallCount();
            int maxBallCount = ballGenerator.GetMaxBallCount();
            remainingBallAmountText.text = "Remaining Balls: " + remainingBallCount + "/" + maxBallCount;
        }
    }
}

