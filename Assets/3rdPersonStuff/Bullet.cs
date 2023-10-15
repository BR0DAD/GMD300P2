using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float lifespan;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0 )
        {
            Destroy(gameObject);
        }
    }

    public void SHOOT(Vector3 direction)
    {
        rb.AddForce(direction.normalized * 5, ForceMode.Impulse);
    }
}
