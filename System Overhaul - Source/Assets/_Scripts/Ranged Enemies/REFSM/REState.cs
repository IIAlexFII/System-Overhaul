using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RE Finite State Machine/State")]

public class REState : ScriptableObject
{
    [SerializeField]
    private REAction entryAction;
    [SerializeField]
    private REAction exitAction;
    [SerializeField]
    private REAction[] stateActions;
    [SerializeField]
    private RETransition[] transitions;

    public REAction GetEntryAction()
    {
        return entryAction;
    }

    public REAction GetExitAction()
    {
        return exitAction;
    }

    public REAction[] GetStateActions()
    {
        return stateActions;
    }

    public RETransition[] GetTransitions()
    {
        return transitions;
    }
}
