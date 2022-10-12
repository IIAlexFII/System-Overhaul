using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public GameObject buletPrefab;
    public float shootime = 2f;
    private float shooTimer = 2;
    public float energy = 20;
    public bool escaped = false;
    public bool playerisdead = false;
    private Health hp;
    private GameObject player;





    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        
    }

    public void GoToNextWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
        currentWaypointIndex += 1;
        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }


    void Update()
    {
        /*if(IsAtDestination(agent))
        {
            int currentWaypoint = Random.Range(0, waypoints.Length);
            //currentWaypoint += 1;
           
            agent.destination = waypoints[currentWaypoint].position;


        }*/
        if (!player)
        {
            playerisdead = true;
        }


    }

    public bool IsAtDestination()
    {
        if(!agent.pathPending)
        {
            if(agent.remainingDistance<= agent.stoppingDistance)
            {
                if(!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void GotoTarget()
    {
        agent.SetDestination(target.position);

    }

    public void RunAway()
    {
        agent.SetDestination(waypoints[0].transform.position);
        escaped = true;

    }

    public void RecoverEnergy()
    {
        if(IsAtDestination() && energy != 20)
        {
            energy += 10 ;
            escaped = false;
        }
    }

    public void Stop()
    {
      
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void Shoot()
    {
        shooTimer += Time.deltaTime;
        if(shooTimer>= shootime)
        {
            
            shooTimer = 0;
            hp.TakeDamage(10f);


        }
    }

}
