using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Actions/Patrol")]

public class REPatrolAction : REAction
{
    public override void Act(REFiniteStateMachine refsm)
    {
        //Debug.Log("Patrol");
        if (refsm.GetAgent().IsAtDestination())
        {
            refsm.GetAgent().GoToNextWaypoint();
        }
    }
}
