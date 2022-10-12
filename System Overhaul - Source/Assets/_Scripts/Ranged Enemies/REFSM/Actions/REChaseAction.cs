using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Actions/Chase")]

public class REChaseAction : REAction
{
    public override void Act(REFiniteStateMachine refsm)
    {
        //Debug.Log("Chase");
        if (refsm.GetAgent().IsAtDestination())
        {
            refsm.GetAgent().GoToTarget();
        }
    }
}
