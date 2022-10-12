using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/Transition")]

public class RETransition : ScriptableObject
{
    [SerializeField]
    private RECondition decision;
    [SerializeField]
    private REAction action;
    [SerializeField]
    private REState targetState;

    public bool IsTriggered(REFiniteStateMachine refsm)
    {
        return decision.Test(refsm);
    }

    public REState GetTargetState()
    {
        return targetState;
    }

    public REAction GetAction()
    {
        return action;
    }
}
