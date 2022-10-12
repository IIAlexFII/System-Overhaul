using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Actions/Death")]

public class REDeathAction : REAction
{
    public override void Act(REFiniteStateMachine refsm)
    {
        Debug.Log("Dead");
        //refsm.GetAgent().Dead();
    }
}
