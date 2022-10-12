using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public GameObject sword;
    public bool attacking;

    private MeleeAttack meleeAttack;
    private void Start()
    {
        meleeAttack = FindObjectOfType<MeleeAttack>();
    }

    private void Update()
    {
        attacking = MeleeAttack.attacking;
        if (meleeAttack.canattack == false)
        {
            attacking = true;
        }
        else
        {
            attacking = MeleeAttack.attacking;
        }
    }
}
