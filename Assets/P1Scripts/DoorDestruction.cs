using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorDestruction : MonoBehaviour
{
    //this is a REALLLLLLY tricky one. it bdestroys the door.
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
