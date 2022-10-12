using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    private Rigidbody rb;
    private Steering[] steerings;
    public float maxAcceleration;
    public float maxAngularAcceleration;
    public float drag;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
    }

    void FixedUpdate()
    {
        Vector3 acceleration = Vector3.zero;
        float rotation = 0;
        foreach (Steering behavior in steerings)
        {
            SteeringData steeringData = behavior.GetSteering(this);
            acceleration += steeringData.linear * behavior.weight;
            rotation += steeringData.angular * behavior.weight;
        }

        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration.Normalize();
            acceleration *= maxAcceleration;
        }

        /*if (rotation > maxAngularAcceleration)
        {
            rotation = maxAngularAcceleration;
        }*/

        rb.AddForce(acceleration);
        if (rotation != 0)
        {
            rb.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}