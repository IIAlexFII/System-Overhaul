using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Conditions/Run Away")]

public class RERunAwayCondition : Condition
{
    [SerializeField]
    private bool hasescaped;

    public override bool Test(FiniteStateMachine fsm)
    {
        if (fsm.GetAgent().escaped == true)
        {
            Debug.Log("Did Escape");
            return hasescaped;
        }
        Debug.Log("Didn't Escape");
        return !hasescaped;

    }
}
