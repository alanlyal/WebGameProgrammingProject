using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            Time.timeScale = pauseCanvas.activeSelf ? 0f : 1f;
        }
    }
}
