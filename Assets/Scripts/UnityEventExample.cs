using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventExample : MonoBehaviour
{
    public UnityEvent OnCubeTouch;
    public UnityEvent OnCubeTouchEnd;

    //on entering the trigger for the cibe this allows the event system to activate. In most cases this is used for light switches
    private void OnTriggerEnter(Collider other)
    {
        OnCubeTouch.Invoke();
    }

    //On some lights exiting the trigger will turn them off
    private void OnTriggerExit(Collider other)
    {
        OnCubeTouchEnd.Invoke();
    }
}
