using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Energy")]
public class EnergyCondiction : Condition { 

 
    [SerializeField]
    private bool low;
    
 
    public override bool Test(FiniteStateMachine fsm)
    {
       if(fsm.GetAgent().energy > 5)
        {
            Debug.Log("high");
            return !low;
        }
        Debug.Log("low");
        return low;

    }
}
