using UnityEngine;
using UnityEngine.UI;

public class SceneSys : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    GameData data;
    void Start()
    {
        
    }

    public void ExitGame ()
    {
        data.SaveGame();
        Application.Quit();
    }
    public void GoToGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void GoToMenu()
    {
        // Load the main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
