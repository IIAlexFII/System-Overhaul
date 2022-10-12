using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Finite State Machine/Conditions/Escaped")]

public class Escaped : Condition
{
    [SerializeField]
    private bool escaped;


    public override bool Test(FiniteStateMachine fsm)
    {
        if (fsm.GetAgent().escaped == true)
        {
            Debug.Log("escaped");
            return escaped;
        }
        Debug.Log("not escaped");
        return !escaped;

    }
}
