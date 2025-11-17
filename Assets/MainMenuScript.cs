using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadGame()
    {
        SceneManager.LoadScene("Plate");
    }

    public void DoExitGame()
    {
        Application.Quit();
    }
    
    public void returnToTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
