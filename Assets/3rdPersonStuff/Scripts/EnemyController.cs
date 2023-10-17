using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    //grabs the animator and as a failsafe ensures the bool is false when it spawns
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("EnemyDead", false);
    }
    
    // when the enemy collides with the boulder or "pinball" they die instantly and play the animation
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Boulder")
        {
            
            animator.SetBool("EnemyDead", true);
            
        }
        
    }
    //adds score for the player, and also destroys the
    //game object making sure that the enemy is gone and deleted from the hierarchy
    private void Death()
    {
        Scoremanager.AddScore(20);
        Destroy(this.gameObject);
    }
        
    
}
