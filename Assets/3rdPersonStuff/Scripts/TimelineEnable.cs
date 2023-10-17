using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineEnable : MonoBehaviour
{
    
    public GameObject Timeline;

    //This makes it so when the player enters the trigger box the cinematic starts
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Timeline.SetActive(true);
        }
    }
}
