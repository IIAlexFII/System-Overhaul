using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Conditions/CanSee")]

public class RECanSeeCondition : RECondition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;

    public override bool Test(REFiniteStateMachine refsm)
    {
        Transform target = refsm.GetAgent().target;
        Vector3 direction = target.position - refsm.transform.position;
        float distance = direction.magnitude;
        float angle = Vector3.Angle(direction.normalized, refsm.transform.forward);

        if ((angle < viewAngle) && (distance < viewDistance))
        {
            return !negation;
        }
        return negation;
    }
}
