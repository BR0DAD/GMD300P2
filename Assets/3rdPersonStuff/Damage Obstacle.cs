using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("3rd Person Character").GetComponent<ThirdCharacterController>().LoseHealth(1);
        }
        
    }
}
