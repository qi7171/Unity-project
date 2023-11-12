using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
