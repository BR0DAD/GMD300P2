using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //makes sure the score is set to 0 again when the player clicks start on the main menu
    public void ButtonClick()
    {
        Scoremanager.Score = 0;
        SceneManager.LoadScene("ClassThirdPerson");
    }
}
