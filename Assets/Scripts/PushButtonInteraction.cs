using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButtonInteraction : MonoBehaviour
{
    public UnityEvent OnButtonPress;

    //when the player presses the button the things attatched to it happen
    public void OnPlayerInteract()
    {
        Debug.Log("HIT!");
        OnButtonPress.Invoke(); 
    }
}
