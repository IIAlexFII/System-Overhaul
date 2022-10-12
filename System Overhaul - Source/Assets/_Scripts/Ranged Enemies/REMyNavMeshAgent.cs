using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMyNavMeshAgent : MonoBehaviour
{
    private LookAtBehavior lookAtBehavior;
    public Transform target;
    public GameObject torunaway;
    public GameObject bulletStartingPos;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public GameObject bulletPrefab;
    public float shootTimeInterval = 1.5f;
    private float shootTimer = 1.5f;

    public float life = 10;
    public float rEnemyMaxLife = 100;

    public bool dead = false;

    private UnityEngine.AI.NavMeshAgent agent;

    //public Transform[] destinations;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        lookAtBehavior = GetComponent<LookAtBehavior>();
    }

    private void Update()
    {
        
    }

    public void GoToNextWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
        lookAtBehavior.target = waypoints[currentWaypointIndex];
    }

    public bool IsAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
        lookAtBehavior.target = target;
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void Shoot()
    {
        shootTimer += Time.deltaTime;
        lookAtBehavior.target = target;
        if (shootTimer >= shootTimeInterval)
        {
            shootTimer = 0; 
            GameObject bullet = Instantiate(bulletPrefab, bulletStartingPos.transform.position + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.position - transform.position) * 80;
        }
        lookAtBehavior.target = target;
        if (Vector3.Distance(transform.position, target.position) < 10f)
        {
            agent.SetDestination(torunaway.transform.position);
        }
    }
}
