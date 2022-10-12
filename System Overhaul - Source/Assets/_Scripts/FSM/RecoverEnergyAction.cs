using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Actions/Recover Energy")]
public class RecoverEnergyAction : Action
{
    public override void Act(FiniteStateMachine fsm)
    {
        
        Debug.Log("Recover Energy");
        fsm.GetAgent().RecoverEnergy();

    }
}
