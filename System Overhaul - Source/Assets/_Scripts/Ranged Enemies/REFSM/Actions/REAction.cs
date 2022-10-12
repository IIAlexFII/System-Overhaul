using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class REAction : ScriptableObject
{
    public abstract void Act(REFiniteStateMachine refsm);
}
