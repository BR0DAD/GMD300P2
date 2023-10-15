using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("EnemyDead", false);
    }
    
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Boulder")
        {
            
            animator.SetBool("EnemyDead", true);
            
        }
        
    }
    private void Death()
    {
        Scoremanager.AddScore(20);
        Destroy(this.gameObject);
    }
        
    
}
