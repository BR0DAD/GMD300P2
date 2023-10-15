using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }
    public void Pause() 
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Pause();
        }
    }
}
