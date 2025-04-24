using UnityEngine;
using UnityEngine.UI;

public class SceneSys : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void GoToGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
