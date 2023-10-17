using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public int CollectibleRequired = 1;

    private int lastUpdatedSlot = 0;

    private Animator animator;

    //on awake grabs the animation components required for the door animation 
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isOpened", false);
    }
    //checks constantly for whatever the score total is and if the animation should play
    private void Update()
    {
        if (MyManager.Instance.GetScoreTotal() > lastUpdatedSlot)
        {
            lastUpdatedSlot++;
            

            if (lastUpdatedSlot == CollectibleRequired)
            {
                animator.SetBool("isOpened", true);
                MyManager.Instance.playerScore = 0;
            }
        }
    }

    
}
