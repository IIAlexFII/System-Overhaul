using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    private MyNavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        agent = GetComponent<MyNavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Transition triggeredTransition = null;
        foreach(Transition transition in currentState.GetTransitions())
        {
            if(transition.IsTriggered(this))
            {
                triggeredTransition = transition;
                break;
            }

        }
        List<Action> actions = new List<Action>();
        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(currentState.GetEntryAction());
            currentState = targetState;

        }
        else
        {
            foreach(Action action in currentState.GetStateAction())
            {
                actions.Add(action);
            }
        }
        foreach(Action action in actions)
        {
            if(action)
            {
                action.Act(this);
            }
        }
    }
    public MyNavMeshAgent GetAgent()
    {
        return agent;
    }
}
