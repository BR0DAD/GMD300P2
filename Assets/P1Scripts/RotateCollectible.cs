using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateCollectible : MonoBehaviour
{

    public float RotateSpeed = 50f;
    public Vector3 RotationAxis = Vector3.up;

    //this causes the object the script it is attatched to rotate
    void Update()
    {
        transform.Rotate(RotationAxis * RotateSpeed * Time.deltaTime);
    }
}
