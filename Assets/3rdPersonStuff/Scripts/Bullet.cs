using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float lifespan;

    //grabs rigidbody component for physics
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //makes it so the ball loses lifespan over time and eventually despawns
    public void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0 )
        {
            Destroy(gameObject);
        }
    }

    //makes it so the ball gets shot in the direction the player is facing
    public void SHOOT(Vector3 direction)
    {
        rb.AddForce(direction.normalized * 20, ForceMode.Impulse);
    }

    //cooperates with Bounce to make sure the lifespan gets increased on a bounce
    public void AddLifespan()
    {
        lifespan += 3;
    }
}
