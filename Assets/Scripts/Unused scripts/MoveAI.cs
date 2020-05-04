using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            
        }
    }

    // Update is called once per frame
    void Update()

    {
        
        if (agent != null)
        {
            if (agent .destination != goal.position)
            {
                agent.destination = goal.position;
            }
        }
    }
}
