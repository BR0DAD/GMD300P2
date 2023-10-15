using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyManager : MonoBehaviour
{
    public static MyManager Instance;

    public int playerScore = 0;


    //ensures only one manager is present
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this) 
        {
            Debug.LogError("More than 1 instance of manager", this);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    //adds score to the player score when the item gets picked up
    public void AddScore(int ScoreToAdd)
    {
        playerScore += ScoreToAdd;
    }

    //removes score from player 
    public void RemoveScore(int ScoreToRemove) 
    {
        playerScore -= ScoreToRemove;

        if(playerScore < 0)
        {
            playerScore = 0;
        }
    }

    //returns the player score when the total score is needed
    public int GetScoreTotal()
    {
        return playerScore;
    }

    //resets score to zero on a failed run
    public void Reset()
    {
        playerScore = 0;
    }
}
