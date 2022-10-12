using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Actions/Run Away")]

public class RERunAwayAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Run Away");
        fsm.GetAgent().RunAway();
    }
}
