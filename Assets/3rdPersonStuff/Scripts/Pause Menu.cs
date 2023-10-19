using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    //continues the gameplay
    public void Resume()
    {
        //Time scale ensures the player isnt moving or is moving as well as other objects
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    //pauses the game making sure all objects in the scene stop moving
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //brings the player back to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //closes the entire application
    public void Quit()
    {
        Application.Quit();
    }
    //checks to see if the players clicks escape so the game can pause
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
