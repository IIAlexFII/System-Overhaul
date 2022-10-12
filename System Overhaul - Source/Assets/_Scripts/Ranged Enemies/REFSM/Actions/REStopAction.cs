using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Actions/Stop")]

public class REStopAction : REAction
{
    public override void Act(REFiniteStateMachine refsm)
    {
        Debug.Log("Stop");
        refsm.GetAgent().Stop();
    }
}
