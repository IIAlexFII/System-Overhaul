using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBehavior : Steering
{
    public Transform target;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steeringData = new SteeringData();

        Vector3 direction = Vector3.Normalize(target.position - transform.position);

        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        steeringData.angular = Mathf.LerpAngle(transform.rotation.eulerAngles.y, angle, steeringbase.maxAngularAcceleration * Time.fixedDeltaTime);

        return steeringData;
    }
}