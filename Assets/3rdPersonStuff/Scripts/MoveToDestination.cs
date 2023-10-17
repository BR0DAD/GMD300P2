using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToDestination : MonoBehaviour
{
    public Transform Destination;
    NavMeshAgent glitch;
    
    // The glitch grabs the nav mesh and starts working in the bounds set 
    void Awake()
    {
        glitch = GetComponent<NavMeshAgent>();

        

    }

    //every frame the AI updates moving towards the destination that is set
    //This is currently set to the player
    private void Update()
    {
        glitch.destination = Destination.position;
    }
}
