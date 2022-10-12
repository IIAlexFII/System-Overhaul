using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : Steering
{
    public float wanderRadius; //5
    public float wanderRate; //0.9
    public float wanderOffset; //5

    private float wanderOrientation = 0;

    private Vector3 AngleToVector3(float angle)
    {
        return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)); 
    }

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();

        wanderOrientation += (Random.value - Random.value) * wanderRate;
        float agentOrientation = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        float targetOrientation = agentOrientation + wanderOrientation;

        Vector3 targetPosition = transform.position + (wanderOffset * AngleToVector3(agentOrientation));

        targetPosition += wanderRadius * AngleToVector3(targetOrientation);

        steeringData.linear = Vector3.Normalize(targetPosition - transform.position);
        steeringData.linear *= steeringbase.maxAcceleration;

        return steeringData;
    }
}
