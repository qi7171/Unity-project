using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        // Restart the game logic
    }

    private void OnQuitButtonClicked()
    {
        // Quit the game logic
    }
}
