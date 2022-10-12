using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Actions/Attack")]

public class REAttackAction : REAction
{
    public override void Act(REFiniteStateMachine refsm)
    {
        Debug.Log("Attack");
        refsm.GetAgent().Shoot();
    }
}
