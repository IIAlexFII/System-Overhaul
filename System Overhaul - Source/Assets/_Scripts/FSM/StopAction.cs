using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Actions/Stop")]
public class StopAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        Debug.Log("Stop");
       
       fsm.GetAgent().Stop();
        
    }
}
