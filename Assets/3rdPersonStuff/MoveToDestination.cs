using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToDestination : MonoBehaviour
{
    public Transform Destination;
    NavMeshAgent glitch;
    
    // Start is called before the first frame update
    void Awake()
    {
        glitch = GetComponent<NavMeshAgent>();

        

    }

    private void Update()
    {
        glitch.destination = Destination.position;
    }
}
