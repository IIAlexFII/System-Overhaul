using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public Slider slider;
    public float currenthp;
    public float maxhp;
    public Renderer mr;
    public Text yourhp;
    public Text maxhealth;
    public bool playertookdamage;
    private bool godmode;
    public GameObject player;
    public float regenSpeed; //Regen speed (wait time)
    public float regenWaitTime; //Time before regen starts
    bool isRegen = false; //If regening
    private IEnumerator couroutine;
    public Checkpoints checkpoint;
    public GameObject gameoverPanel;
    private bool death;




    // Start is called before the first frame update
    void Start()
    {
        godmode = false;
        currenthp = maxhp;
        slider.gameObject.SetActive(true);
        mr = gameObject.GetComponent<Renderer>();
        playertookdamage = false;
        gameoverPanel.gameObject.SetActive(false);
        death = false;


    }

    // Update is called once per frame
    void Update()
    {
        DeathCheats();
        yourhp.text = "" + (int)currenthp + " /";
        maxhealth.text = "" + maxhp;
        Respawn();
        HpCheats();
     
  
        if (transform.position.y <= -4)
        {
         
            //transform.position = new Vector3(Checkpoints.lastposition.x, Checkpoints.lastposition.y + 2, Checkpoints.lastposition.z);
        }

        slider.value = currenthp / maxhp;
        
        if (currenthp != maxhp && !isRegen)
        { //If they have health less than max

            couroutine = Regen();
            StartCoroutine(couroutine); //Start regen
        }
        if (mr.material.color != Color.white)
        {
            Invoke("ColorChange", 0.2f);

        }
   




    }
    public void Heal(float heal)
    {
        currenthp += heal;
        if (currenthp > maxhp && godmode == false)
        {
            currenthp = maxhp;

        }
        mr.material.color = Color.green;




    }
    public void TakeDamage(float damage)
    {
    
        if (isRegen)
        {
            StopCoroutine(couroutine);
            isRegen = !isRegen;
        }
     
        if (!Shield.shielded)
        {

            
            currenthp -= damage;

            if (currenthp <= 0)
            {
                gameoverPanel.gameObject.SetActive(true);
                death = true;
                Time.timeScale = 0f;


            }
            if (damage > 0)
            {
              
                mr.material.color = Color.red;
            }
           

        }   
    }

    public void ColorChange()
    {
        if(mr.material.color != Color.white)
        {
            mr.material.color = Color.white;
        }
    }


    IEnumerator Regen()
    {
        isRegen = true; //Set regenning to true
        yield return new WaitForSeconds(regenWaitTime); //Wait for delay

        while (currenthp < maxhp)
        { //Start the regen cycle
            currenthp += 1; //Increase health by 1
            yield return new WaitForSeconds(regenSpeed); //Wait for regen speed
            
        }
        isRegen = false; //Set regenning to false
    }

    public void HpCheats()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            currenthp = 1000;
            godmode = true;

        }
    }

    public void DeathCheats()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
        {
            //player.transform.position = Checkpoints.lastposition;
            currenthp = 0;
            Debug.Log("CheckpPoint");
            
        }
       
    }

    public void Respawn()
    {

        if (Input.GetKey(KeyCode.R) && death == true)
        {
            player.transform.position = Checkpoints.lastposition;
            currenthp = 100;
            gameoverPanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
            death = false;
        }
    }

}

