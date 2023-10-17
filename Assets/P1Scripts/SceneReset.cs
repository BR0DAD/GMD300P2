using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{

    //When the player collides with the empty game object the scene resets itself
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MyManager.Instance.Reset();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
    }

    
}
