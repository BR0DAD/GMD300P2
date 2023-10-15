using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineEnable : MonoBehaviour
{
    public GameObject Timeline;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Timeline.SetActive(true);
        }
    }
}
