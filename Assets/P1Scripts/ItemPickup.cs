using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{

    public UnityEvent playSound;

    //when you pickup the collectible this adds it to the inventory and plays a silly sound
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MyManager.Instance.AddScore(1);

            Destroy(this.gameObject);

            playSound.Invoke();
        }
    }
}
