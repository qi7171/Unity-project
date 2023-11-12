using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;


/*public class BallGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object to generate

    private GameObject currentObject; // Reference to the current active object

    public void Start()
    {
        GenerateNewObject();
    }

    public void GenerateNewObject()
    {
        // Destroy the previous object if it exists
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        // Instantiate a new object from the prefab at the original position
        currentObject = Instantiate(objectPrefab, transform.position, transform.rotation);

        // Disable physics components (rigidbody and collider) if present
        Rigidbody objectRigidbody = currentObject.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }

        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }

        // Attach the HittingObjectDisappear script to the new object
        HittingObjectDisappear disappearScript = currentObject.AddComponent<HittingObjectDisappear>();
        disappearScript.ballGenerator = this;
    }
}*/



/*public class BallGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object to generate

    private GameObject currentObject; // Reference to the current active object
    private Vector3 originalPosition; // Original position of the ball

    public void Start()
    {
        originalPosition = transform.position;
        GenerateNewObject();
    }

    public void Update()
    {
        if (currentObject != null && Input.GetButtonDown("GripButton")) // Replace "GripButton" with the actual input button for the grip action
        {
            ResetBallPosition();
        }
    }

    public void GenerateNewObject()
    {
        // Destroy the previous object if it exists
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        // Instantiate a new object from the prefab at the original position
        currentObject = Instantiate(objectPrefab, originalPosition, transform.rotation);

        // Disable physics components (rigidbody and collider) if present
        Rigidbody objectRigidbody = currentObject.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }

        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
    }

    public void ResetBallPosition()
    {
        if (currentObject != null)
        {
            currentObject.transform.position = originalPosition;
        }
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab; // Reference to the prefab of the ball to generate
    public Transform[] spawnPoints; // Array of manually defined spawn points
    private List<GameObject> balls; // List to store the generated balls

    public int maxBallCount = 5; // Maximum number of balls-------------------------------------------------------------


    private int remainingBallCount;// ===================================NE2.0
    private void Start()
    {
        //====================NE2.0
        maxBallCount = spawnPoints.Length+1;
        remainingBallCount = maxBallCount;
        //-----------------------------

        GenerateBalls();
    }

    private void GenerateBalls()
    {
        balls = new List<GameObject>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i];

            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
            balls.Add(ball);
        }
    }

    public void BallHit(GameObject ball)
    {
        if (balls.Contains(ball))
        {
            balls.Remove(ball);
            Destroy(ball);
          //  DecrementBallCount();//-----------------------------------------------------------------------------------
        }
    }
    public void DecrementBallCount()//----------------------
    {
        // maxBallCount--;

        //=============================NE2.0
        remainingBallCount--;
        UpdateRemainingBallCountText();

        if (remainingBallCount == 0)
        {
            // Implement game over logic here
        }
    }
    public int GetRemainingBallCount()//--------------------------------
    {
        // return balls.Count;//--------------------------------

        return remainingBallCount;//==============NE2.0
    }

    public int GetMaxBallCount()//--------------------------------
    {
        return maxBallCount;//--------------------------------
    }


    //==========================NE2.0
    private void UpdateRemainingBallCountText()
    {
        Debug.Log("Remaining Balls: " + remainingBallCount);
        // Update the remaining ball count text
    }
}

