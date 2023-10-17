using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasScoreUpdate : MonoBehaviour
{
    public TMP_Text ScoreText;

    //finds game manager so whenever the scene resets it attatches a manager properly to the canvas

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Scoremanager.Score.ToString();
    }
}
