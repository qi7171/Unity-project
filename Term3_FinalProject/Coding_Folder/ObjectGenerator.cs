using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object to generate
    public Transform spawnPoint; // Position where the new object should be spawned

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

        // Instantiate a new object from the prefab at the spawn point
        currentObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

        // Attach the DisappearOnCollision script to the new object
        DisappearOnCollision disappearScript = currentObject.AddComponent<DisappearOnCollision>();
        disappearScript.objectGenerator = this;
    }
}*/





//GENERATE REPEARTEDLY

/*public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object to generate
    public Transform[] spawnPoints; // Array of spawn points

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

        // Select a random spawn point index
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate a new object from the prefab at the selected spawn point
        currentObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

        // Disable physics components (rigidbody and collider) if present
        Rigidbody objectRigidbody = currentObject.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }

        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            // objectCollider.enabled = false;
            objectCollider.enabled = true;
        }

        // Attach the DisappearOnCollision script to the new object
        DisappearOnCollision disappearScript = currentObject.AddComponent<DisappearOnCollision>();
        disappearScript.objectGenerator = this;
    }

    public void EnableObjectCollider()
    {
        // Enable the collider of the current object
        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            objectCollider.enabled = true;
        }
    }
}*/


//---------------------------------------------------------GENERATE WITH A COUNTER---------------------------------------------------------------------------------------------------

/*using UnityEngine.SceneManagement;
using TMPro;


public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object to generate
    public Transform[] spawnPoints; // Array of spawn points
    public int maxGenerationCount = 5; // Maximum number of object generations before game over
    public float timeLimit = 60f;

    private int generationCount = 0; // Counter for the number of object generations
    private GameObject currentObject; // Reference to the current active object
    private bool gameEnded = false; // Flag to track if the game has ended
    private float timer = 0f; // Timer to track the elapsed time


    public TextMeshProUGUI countText; // Text component to display the count
    public TextMeshProUGUI timerText; // Text component to display the timer

    public bool IsNewObject = true;


    public GameObject gameOverPanel; // Reference to the game over panel object


    //====================================================================================================

    public void Start()
    {
        GenerateNewObject();

        // Initialize the timer
        timer = 0f;

        //print the generation count
        generationCount = 0;
        UpdateCountText();

        // Update the timer text
        UpdateTimerText();

        gameOverPanel.SetActive(false);

    }

    public void Update()
    {
        if (gameEnded)
        {
            // Check for restart or quit input when the game has ended
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
            return;
        }


        // Increment the timer
        timer += Time.deltaTime;

        // Check if the time limit has been reached
        if (timer >= timeLimit)
        {
            // End the game
            EndGame();
        }

        // Update the timer text
        UpdateTimerText();
    }

    //--------------------------------------------------------------------------------------------------------
    public void GenerateNewObject()
    {
        // Destroy the previous object if it exists
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        // Check if the maximum generation count has been reached
        if (generationCount >= maxGenerationCount)
        {
            // End the game (reload the current scene)
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Check if the game has already ended
            //if (!gameEnded)
            //{
                // Display options to restart or quit
               //Debug.Log("Press R to restart or Q to quit.");
                //gameEnded = true;
           // }

            // End the game
            EndGame();
            Debug.Log("You Win!");
            gameOverPanel.SetActive(true);
            return;
        }

        // Select a random spawn point index
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate a new object from the prefab at the selected spawn point
        currentObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        // currentObject.transform.parent = transform; // Set the ObjectGenerator as the parent of the new object


        // Disable physics components (rigidbody and collider) if present
        Rigidbody objectRigidbody = currentObject.GetComponent<Rigidbody>();

        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }

        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            // objectCollider.enabled = false;
            objectCollider.enabled = true;
        }


        // Set IsNewObject to true for the new object
        IsNewObject = true;

        // Attach the DisappearOnCollision script to the new object
        DisappearOnCollision disappearScript = currentObject.AddComponent<DisappearOnCollision>();
        disappearScript.objectGenerator = this;

        // Increment the generation count
        generationCount++;

        UpdateCountText();
    }

    public void EnableObjectCollider()
    {
        // Enable the collider of the current object
        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            objectCollider.enabled = true;
        }
    }


    public void UpdateCountText()
    {
        //countText.text = "Generation Count: " + generationCount.ToString();
        if (generationCount >= maxGenerationCount)
        {
            countText.text = "You Win!";

        }
        else
        {
            countText.text = "Generation Count: " + generationCount.ToString();
        }
    }

    public void UpdateTimerText()
    {
        float timeRemaining = Mathf.Clamp(timeLimit - timer, 0f, timeLimit);
        timerText.text = "Time: " + timeRemaining.ToString("F1") + "s";
    }

    private void EndGame()
    {
        // Set the game ended flag
        gameEnded = true;

        // Display options to restart or quit
        Debug.Log("Press R to restart or Q to quit.");

        // Enable the game over panel
        gameOverPanel.SetActive(true);

        // Disable any other UI elements if necessary
        countText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        timer = 0f;

        // Reset generation count and restart the game
        generationCount = 0;
        gameEnded = false;
        GenerateNewObject();

        UpdateCountText();
        UpdateTimerText();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void IncrementCounter()
    {
        generationCount++;
        UpdateCountText();
    }


}*/


//=======================================================Edited on Jun.3th=============================================
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the object to generate
    public Transform[] spawnPoints; // Array of spawn points
    public int maxGenerationCount = 5; // Maximum number of object generations before game over
    public float timeLimit = 60f;

    private int generationCount = 1; // Counter for the number of object generations
    private GameObject currentObject; // Reference to the current active object
    private bool gameEnded = false; // Flag to track if the game has ended
    private float timer = 0f; // Timer to track the elapsed time

    public TextMeshProUGUI countText; // Text component to display the count
    public TextMeshProUGUI timerText; // Text component to display the timer
    public TextMeshProUGUI countText1; // Text component to display the count
    public TextMeshProUGUI timerText1; // Text component to display the timer
    public TextMeshProUGUI countText2; // Text component to display the count
    public TextMeshProUGUI timerText2; // Text component to display the timer


    public GameObject gameOverPanel; // Reference to the game over panel object

    public BallGenerator ballGenerator; // Reference to the BallGenerator script

    public bool IsNewObject = true;

    public GameObject hitTarget; // Reference to the HitTarget game object
    public GameObject hitSheild; // Reference to the HitSheild game object


    //----------------------------------------------------------------------------------
    public List<GameObject> ivyObjects;
    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    //----------------------------------------------------------------

    private void Start()
    {
        timer = 0f;
        gameEnded = false;

        GenerateNewObject();
        UpdateCountText();
        UpdateTimerText();

        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (gameEnded)
        {
            // Check for restart or quit input when the game has ended
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame();
            }
            return;
        }

        // Increment the timer
        timer += Time.deltaTime;

        // Check if the time limit has been reached
        if (timer >= timeLimit)
        {
            // End the game
            EndGame();
        }

        //------------------------------------newly edited 2,0-----------------------------
        // Check if the remaining ball amount is zero and the generation count is less than the maximum
        if (ballGenerator.GetRemainingBallCount() == 0 && generationCount < maxGenerationCount)
        {
            // End the game
            EndGame();
        }
        //--------------------------------------------------------------------------------



        // Update the timer text
        UpdateTimerText();
    }

    public void GenerateNewObject()
    {
        // Destroy the previous object if it exists
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        // Check if the maximum generation count has been reached
        if (generationCount > maxGenerationCount)
        {
            // End the game
            EndGame();
            return;
        }

        // Select a random spawn point index
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate a new object from the prefab at the selected spawn point
        currentObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);



        //================================================NE3.0
        Rigidbody objectRigidbody = currentObject.GetComponent<Rigidbody>();

        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = false;
        }

        Collider objectCollider = currentObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            // objectCollider.enabled = false;
            objectCollider.enabled = true;
        }


        // Set IsNewObject to true for the new object
        IsNewObject = true;

        //======================================================

        // Attach the DisappearOnCollision script to the new object
        DisappearOnCollision disappearScript = currentObject.AddComponent<DisappearOnCollision>();
        disappearScript.objectGenerator = this;

        // Increment the generation count
        generationCount++;

        // Update the count text
        UpdateCountText();
    }

    public void UpdateCountText()
    {
       /* if (generationCount >= maxGenerationCount)
        {
            countText.text = "You Win!";
        }
        else
        {*/
            countText.text = "Generation Count: " + generationCount.ToString();
            countText1.text = "Generation Count: " + generationCount.ToString();
            countText2.text = "Generation Count: " + generationCount.ToString();
        //  }
    }

    public void UpdateTimerText()
    {
        float timeRemaining = Mathf.Clamp(timeLimit - timer, 0f, timeLimit);
        timerText.text = "Time: " + timeRemaining.ToString("F1") + "s";
        timerText1.text = "Time: " + timeRemaining.ToString("F1") + "s";
        timerText2.text = "Time: " + timeRemaining.ToString("F1") + "s";
    }

   public void EndGame()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
       // countText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);


        //----------------------------------------------newly edited==========================================
        if (ballGenerator.GetRemainingBallCount() == 0 && timer< timeLimit)
        {
            countText.gameObject.SetActive(false);
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "No Ball";
            //----------------------------------------------------------
            ShowAllIvyObjects();
            // Play audio clip 1
            audioSource.clip = audioClip1;
            // Play the audio clip
            audioSource.Play();

            //-----------------------------------------
        }
        else if (timer >= timeLimit)
        {
            countText.gameObject.SetActive(false);
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Times Up";

            //----------------------------------------------------------
            ShowAllIvyObjects();
            // Play audio clip 1
            audioSource.clip = audioClip1;
            // Play the audio clip
            audioSource.Play();
            //----------------------------------------
        }
        //------------------------------------------------------------------------------

        //--------------------------------------NE4.0
        if (generationCount >= maxGenerationCount)
        {
            countText.gameObject.SetActive(true);
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You Win";

            //------------------------------------------------------
            HideAllIvyObjects();
            // Play audio clip 2
            audioSource.clip = audioClip2;
            audioSource.Play();
        }

        // Hide the HitSheild and HitTarget game objects
        hitSheild.SetActive(false);
        hitTarget.SetActive(false);
    }

    public void RestartGame()
    {
        timer = 0f;
        generationCount = -1;
        gameEnded = false;

        ballGenerator.DecrementBallCount(); // Decrement the ball count in BallGenerator--------------------------------------------

        GenerateNewObject();
        UpdateCountText();
        UpdateTimerText();

        gameOverPanel.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void IncrementCounter()
    {
      //  generationCount++;
        UpdateCountText();
    }

    public void DecrementTargetAmount()//-----------------------------------------
    {
        maxGenerationCount--;
    }



    //---------------------------------------------------------------------------------------------------------------------
    private void ShowAllIvyObjects()
    {
        foreach (GameObject ivyObject in ivyObjects)
        {
            ivyObject.SetActive(true);
        }
    }

    private void HideAllIvyObjects()
    {
        foreach (GameObject ivyObject in ivyObjects)
        {
            ivyObject.SetActive(false);
        }
    }
}
