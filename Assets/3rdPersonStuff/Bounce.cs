using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float power = 5f; 
    private void OnCollisionEnter(Collision col)
    {
         
        if (col.gameObject.transform.tag == "Boulder")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,0) * power);
        }
    }
}
