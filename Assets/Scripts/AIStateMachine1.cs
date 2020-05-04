using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class AIStateMachine1 : MonoBehaviour
{
    private Rigidbody agent;

    #region Player chasing
    public GameObject player;
    public float distanceToChase = 5f;
    public float distanceToStopChase = 20f;
    public Transform FleeToWaypoint;
    public PlayerMovement playerMovement;
    public float DamagePlayerDistance;
    public float DealDamage;
    public float DealtDamage;
    float AttackCooldown = 0.75f;
    float TimeOfAttack = float.MinValue;
    public float AIHealth = 100;
    public float MaxAIHealth = 100;
    #endregion

    #region waypoint variables
    public Transform[] waypoints;
    public float speed;
    private int currentWaypoint = 0;
    public float minDistanceToWaypoint = 1.5f;
    public float minDistanceToFlee = 1.5f;
    #endregion

    #region Wait Variables
    public float waitTime = 2f;
    #endregion

    public enum State //creates the states/modes for the AI
    {
        Patrol,
        Chase,
        Wait,
        Death,
        Flee,
    }

    public State state;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();

        agent = GetComponent<Rigidbody>();

        if (agent == null)
        {
            Debug.LogError("Agent not attached to MoveAI");
        }
        
        NextState();
    }


    IEnumerator PatrolState()
    {// patrol tells the AI to move from way point to waypoint while checking to see if the player is within chasing range
        Debug.Log("Patrol: Enter");
        while (state == State.Patrol)
        {
            // void Update()
            //{

                    Patrol();

                    CheckForChase();
            
            
            //}
            yield return 0;
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }

    IEnumerator WaitState()
    {// wait tells the AI to stop moving for a certain period of time before moving to the next waypiont
        Debug.Log("Wait: Enter");
        float waitStartTime = Time.time;
        while (state == State.Wait)
        {
            

                if (Time.time > waitStartTime + waitTime)// 2 seconds passed
                {
                    state = State.Patrol;
                }

                CheckForChase();
            
            yield return 0;
        }
        Debug.Log("Wait: Exit");
        NextState();
    }

    IEnumerator ChaseState()
    {//chase tells the AI to follow after the player when within the specified distance to the player and to attack
        Debug.Log("Chase: Enter");
        while (state == State.Chase)
        {
            Move(player.transform.position);

            if(Vector3.Distance(player.transform.position, agent.transform.position) > distanceToStopChase)
            {
                if (AIHealth < 25 % MaxAIHealth && AIHealth < playerMovement.Health)
                {

                    
                    state = State.Flee;
                }
                else
                {
                    state = State.Patrol;
                }
                
            }

            if (Vector3.Distance(player.transform.position, agent.transform.position) < DamagePlayerDistance)
            {
                if (Time.time > TimeOfAttack + AttackCooldown)
                {
                    playerMovement.TakeDamage(DealDamage);
                    TimeOfAttack = Time.time;
                }
                if (Input.GetKeyDown("z"))
                {
                    AIDamage(DealtDamage);
                    
                }
                

            }


            
            CheckForChase();

            yield return 0;
        }
        Debug.Log("Chase: Exit");
        NextState();
    }

    IEnumerator DeathState()
    {//death tells the AI to stop moving and to destroy itself over 5 seconds when enough damage is taken
        Debug.Log("Death: Enter");
        while (state == State.Death)
        {
            
            
            Destroy(agent.gameObject, 5f);
            
            yield return 0;
        }
        Debug.Log("Death: Exit");
        NextState();
    }
    IEnumerator FleeState()
    {//flee tells the AI to move to the waypoint tagged fleepoint when enough damage has been taken 
        Debug.Log("Flee: Enter");
        while (state == State.Flee)
        {
            
            if (FleeToWaypoint != null)
            {
                if (agent.position != FleeToWaypoint.position)
                {
                    agent.position = Vector3.MoveTowards(agent.position, FleeToWaypoint.position, speed * Time.deltaTime);
                }
            }
            if (Vector3.Distance(agent.transform.position, FleeToWaypoint.transform.position) < minDistanceToFlee)
            {
                state = State.Wait;
                currentWaypoint++;
            }
            if (Vector3.Distance(player.transform.position, agent.transform.position) < DamagePlayerDistance)
            {
                if (Time.time > TimeOfAttack + AttackCooldown)
                {
                    playerMovement.TakeDamage(DealDamage);
                    TimeOfAttack = Time.time;
                }
                if (Input.GetKeyDown("z"))
                {
                    AIDamage(DealtDamage);

                }


            }
           
            yield return 0;
        }
        Debug.Log("Flee: Exit");
        NextState();
    }

    void NextState() //changes from current state to the next state in the list
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                   System.Reflection.BindingFlags.NonPublic |
                                   System.Reflection.BindingFlags.Instance);

        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }



    public void Patrol()
    {
        Debug.Log(agent);
        Debug.Log(waypoints);

        if (Vector3.Distance(agent.position, waypoints[currentWaypoint].transform.position) < minDistanceToWaypoint)
        {
            state = State.Wait;
            currentWaypoint++;
        }
        if (currentWaypoint >= waypoints.Length)
        {
            
            currentWaypoint = 0;
        }

        Move(waypoints[currentWaypoint].transform.position);
    }

    public void Move(Vector3 destination)
    {
        if (destination != null)
        {
            if (agent.position != destination)
            {
                agent.position = Vector3.MoveTowards(agent.position, destination, speed * Time.deltaTime);
            }

        }
        
    }

    

    public void CheckForChase()
    {
        if(Vector3.Distance(player.transform.position, agent.transform.position) < distanceToChase)
        {
            state = State.Chase;
        }
    }
    private void Update()
    {
        if (AIHealth < 25 % MaxAIHealth && AIHealth < playerMovement.Health)
        {

            
            state = State.Flee;
        }

        if (AIHealth <= 0)
        {

            state = State.Death;
            
        }
    }

    public void AIDamage(float damage)
    {
        AIHealth -= damage;
    }
}
