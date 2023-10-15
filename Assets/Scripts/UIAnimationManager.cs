using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIAnimationManager : MonoBehaviour
{
    public static UIAnimationManager instance;

    private Animator animator;

    //makes it so there is only one animator
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;  

        } else if(instance != this)
        {
            Destroy(this);
        }

        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        if (instance == this ) 
        {
            instance = null;
        }
    }

    //allows the UI for the imteract prompt to show up
    public void ShowInteractPrompt(bool showPrompt)
    {
        animator.SetBool("showInteractionPrompt", showPrompt);
    }

}
