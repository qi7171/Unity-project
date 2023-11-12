using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class VRButtonHandler : MonoBehaviour
{
    public UnityEvent onRestartButtonClicked; // Unity Event for restart button click action
    public UnityEvent onQuitButtonClicked; // Unity Event for quit button click action

    // Method to handle restart button click
    public void RestartButtonClicked()
    {
        // Add your restart logic here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        onRestartButtonClicked.Invoke();
        Debug.Log("RestartButtonClicked");


    }

    // Method to handle quit button click
    public void QuitButtonClicked()
    {
        // Load the desired scene by name or index
        SceneManager.LoadScene("FunctionScene");
        Debug.Log("Quit Successfully");

    }
}

