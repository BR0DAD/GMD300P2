using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{

    //makes this so when the player collides with an enemy, they lose HP
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("3rd Person Character").GetComponent<ThirdCharacterController>().LoseHealth(1);
        }
        
    }
}
