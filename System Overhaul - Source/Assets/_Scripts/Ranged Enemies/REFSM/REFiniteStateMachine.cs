using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REFiniteStateMachine : MonoBehaviour
{
    public REState initialState;
    public REState currentState;
    private REMyNavMeshAgent agent;

    void Start()
    {
        currentState = initialState;
        agent = GetComponent<REMyNavMeshAgent>();
    }

    public REMyNavMeshAgent GetAgent()
    {
        return agent;
    }

    void Update()
    {
        RETransition triggeredTransition = null;
        foreach (RETransition transition in currentState.GetTransitions())
        {
            if (transition.IsTriggered(this))
            {
                triggeredTransition = transition;
                break;
            }
        }

        List<REAction> actions = new List<REAction>();

        if (triggeredTransition)
        {
            REState targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;
        }
        else
        {
            foreach (REAction action in currentState.GetStateActions())
            {
                actions.Add(action);
            }
        }

        foreach (REAction action in actions)
        {
            if (action)
            {
                action.Act(this);
            }
        }
    }
}