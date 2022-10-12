using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        //Debug.Log("Chase");
        if (fsm.GetAgent().IsAtDestination())
        {
            fsm.GetAgent().GotoTarget();
        }
    }
}
