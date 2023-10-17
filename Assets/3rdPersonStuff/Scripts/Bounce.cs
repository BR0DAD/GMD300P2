using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bounce : MonoBehaviour
{
    //so the launch distance can be changed
    [SerializeField] private float power = 5f; 
    private void OnCollisionEnter(Collision col)
    {
         //this ensures that when the pinball hits the obstacle, it adds force to the ball shooting it back
         //out and also adds a bit of lifespan to the ball, so it can maybe combo
        if (col.gameObject.transform.tag == "Boulder")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,0) * power);
            col.gameObject.GetComponent<Bullet>().AddLifespan();
        }
    }
}
