using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Conditions/Dead")]

public class REDeadCondition : RECondition
{
    public bool isdead;
    public override bool Test(REFiniteStateMachine refsm)
    {
        if (refsm.GetAgent().life <= 0)
        {
            return isdead;
        }
        return !isdead;
    }
}
