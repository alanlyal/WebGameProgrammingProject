
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Main;
    public void PlayGame()
    {
        SceneManager.LoadScene("level");
    }
    public void QuitGame()
    { 
    Application.Quit();
        Debug.Log("game has closed");
    }
    public void OpenSettings()
    { 
        Settings.SetActive(true);
        Main.SetActive(false);
    }
    public void CloseSettings()
    {
        Settings.SetActive(false);
        Main.SetActive(true);
    }
}
