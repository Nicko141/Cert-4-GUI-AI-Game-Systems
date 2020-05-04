using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public Transform Waypoint1;
    public Transform Waypoint2;
    public float speed;
    public Transform AI;
    public GameObject Player;
    public GameObject[] waypoints;
    public PlayerMovement playerController;
    public float ChasePlayerDistance;
    public float DamagePlayerDistance;
    public float DealDamage;
    int currentWaypoint = 0;
    float AttackCooldown = 0.75f;
    float TimeOfAttack = float.MinValue;
    // Start is called before the first frame update
    void Start()
    {
        playerController = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, AI.transform.position) < DamagePlayerDistance)
        {
            if(Time.time > TimeOfAttack + AttackCooldown)
            {
                playerController.TakeDamage(DealDamage);
                TimeOfAttack = Time.time;
            }
        }
        // Patrol();
        else if (Vector3.Distance(Player.transform.position, AI.transform.position) < ChasePlayerDistance)
        {
            MoveAI(Player.transform.position); 

        }
        else
        {
            Patrol();

        }

        
    }
    private void Patrol()
    {


        if (Vector3.Distance(AI.position, waypoints[currentWaypoint].transform.position) < 0.001f)
        {
            currentWaypoint++;
        }

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }


        MoveAI(waypoints[currentWaypoint].transform.position);
    }
    private void MoveAI(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(AI.position, targetPosition, speed * Time.deltaTime);
    }

    
}
