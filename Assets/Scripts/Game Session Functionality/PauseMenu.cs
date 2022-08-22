using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
        pauseMenu.SetActive(false);
    }

 
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    public void Quit()
    {
        Debug.Log("quitting");
        Debug.Log("Maybe go to main menu scene if we  end up having one instead of just quitting?");
        Application.Quit();
    }

   
}
