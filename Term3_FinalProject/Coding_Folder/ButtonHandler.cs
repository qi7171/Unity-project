using UnityEngine;

public class ButtonHandler : MonoBehaviour
{


    public GameObject gameTitleObject;
    public GameObject gameIntroObject;
    public GameObject playIntroObject;
    public Animator animator; // Reference to the Animator component
    private bool isAnimationPlaying = false;


    void Start()
    {
        animator.enabled = false;
        // Show the game title object
        gameTitleObject.SetActive(true);

        // Hide the game intro object
        gameIntroObject.SetActive(false);

        // Hide the play intro object
        playIntroObject.SetActive(false);
    }

    public void OnGameTitleButtonClicked()
    {
        animator.enabled = true;
        

        // Hide the game title object after a delay
        Invoke("HideGameTitleObject", 0.5f);
    }

    private void HideGameTitleObject()
    {
        animator.enabled = false;
      
        // Hide the game title object
        gameTitleObject.SetActive(false);

        // Show the game intro object
        gameIntroObject.SetActive(true);
    }


    public void OnGameIntroButtonClicked()
    {
        animator.enabled = true;
        
        // Hide the game intro object after a delay
        Invoke("HideGameIntroObject", 0.5f);
    }
    private void HideGameIntroObject()
    {
        animator.enabled = false;

        // Hide the game title object
        gameTitleObject.SetActive(false);
        // Hide the game intro object
        gameIntroObject.SetActive(false);

        // Show the play intro object
        playIntroObject.SetActive(true);
    }


 
}
