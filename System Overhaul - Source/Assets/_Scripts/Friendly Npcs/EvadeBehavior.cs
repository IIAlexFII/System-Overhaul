using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeBehavior : Steering
{
    public Transform[] target;
    public float maxprediction;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();

        foreach (Transform enemy in target)
        {
            Vector3 direction = enemy.position - transform.position;
            float distance = direction.magnitude;
            float speedagent = GetComponent<Rigidbody>().velocity.magnitude;

            float prediction;

            if (speedagent <= distance / maxprediction)
            {
                prediction = maxprediction;
            }
            else
            {
                prediction = distance / speedagent;
            }

            Vector3 futurePosition = enemy.position + (enemy.GetComponent<Rigidbody>().velocity * prediction);

            steeringData.linear = Vector3.Normalize(futurePosition - transform.position) * -1;
            steeringData.linear *= steeringbase.maxAcceleration;
        }

        return steeringData;
    }
}
