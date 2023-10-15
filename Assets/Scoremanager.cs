using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scoremanager
{
    public static int Score;

    //adds score to the player score when the item gets picked up
    public static void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
    }
}
