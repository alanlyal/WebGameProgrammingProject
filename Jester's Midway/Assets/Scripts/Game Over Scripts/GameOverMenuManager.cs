
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuManager: MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("level");
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("menu");
    }
}
