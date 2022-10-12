using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{
    public GameObject sword;
    public static float meleeDamage = 10;
    private float meleeattacktimer = 1f;
    public float swordMoveSpeed = 150f;
    public Quaternion startingrotation;
    public static bool attacking = false;
    public bool canattack = true;

    public Button MeleeDamageButton;

    public Animator myAnim;

    private void Start()
    {
       
       
        myAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (canattack)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        canattack = false;
        attacking = true;
        Debug.Log("Is Attacking");
        myAnim.SetTrigger("MeleeAttack");
        meleeattacktimer = 0f;
        StartCoroutine(ResetMeleeAttackTimer());
    }

    IEnumerator ResetMeleeAttackTimer()
    {
        yield return new WaitForSeconds(meleeattacktimer);
    }

  

    public void AnimationEnded()
    {
        canattack = true;
        attacking = false;
    }

    public void DamageUpgrade()
    {
        if (ComputerChips.Computerchips >= 3)
        {
            meleeDamage = 15;
            ComputerChips.Computerchips -= 3;
            ComputerChips.ChipsText.text = "" + ComputerChips.Computerchips;
            Destroy(MeleeDamageButton);
        }
    }
}
