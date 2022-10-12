using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shield : MonoBehaviour
{
    public float shieldtime = 5;
    public float shieldduration = 0;
    public static bool shielded;
    public GameObject shieldbarrier;
    public Text shieldcooldown;
    public float cooldowndecreasing;
    public float duration = 3;
    public Button shieldbutton;

    private Image shieldimage;

    // Start is called before the first frame update
    void Start()
    {
        shieldimage = GameObject.FindGameObjectWithTag("Shield Button").GetComponent<Image>();
        shieldduration = shieldtime;
        cooldowndecreasing = (int)shieldduration;
        shieldcooldown.gameObject.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {

        shield();
    }

    public void shield()
    {
        
        float alpha = shieldduration / shieldtime;
        if (alpha > 1f)
        {
            alpha = 1f;

        }
        shieldimage.color = new Color(1f, 1f, 1f, alpha * 0.5f + 0.5f);

        cooldowndecreasing -= Time.deltaTime;
        shieldduration += Time.deltaTime;
        if (Input.GetKey(KeyCode.R) && shieldduration >= shieldtime && !shielded)
        {
   
            Debug.Log("shield up");
            cooldowndecreasing = 5;
            shieldduration = 0;
            shielded = true;
            shieldcooldown.gameObject.SetActive(true);
            shieldbarrier.gameObject.SetActive(true);
            Invoke("ShieldGone", duration);
        }
        if(shieldduration >= shieldtime)
        {
            shieldcooldown.gameObject.SetActive(false);
        }
        else
        {
            shieldcooldown.text = "" + (int)cooldowndecreasing;
        }




    }

    public void ShieldGone()
    {
        shielded = false;
        shieldbarrier.gameObject.SetActive(false);
   
    }

    public void UpgradesShield()
    {
        if (ComputerChips.Computerchips >= 5) {
            duration = 5;
            ComputerChips.Computerchips -= 5;
            ComputerChips.ChipsText.text = "" + ComputerChips.Computerchips;
            Destroy(shieldbutton);
        }
    }
  
}
