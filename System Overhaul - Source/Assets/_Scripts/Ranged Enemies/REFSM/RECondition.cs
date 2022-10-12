using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RECondition : ScriptableObject
{
    public abstract bool Test(REFiniteStateMachine refsm);
}
