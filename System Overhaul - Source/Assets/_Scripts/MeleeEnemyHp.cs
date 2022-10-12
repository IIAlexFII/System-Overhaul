using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeEnemyHp : MonoBehaviour
{
    public Slider slider;

    public float currenthp;
    public float maxhp;
    public Vector3 Offset;

    public Vector3 playerDir;
    public GameObject player;

    private void Start()
    {
        slider.gameObject.SetActive(false);
        currenthp = maxhp;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        slider.value = currenthp / maxhp;
        CanvasController();
    }

    public void TakeDamage(float damage)
    {

        currenthp -= damage;
        slider.gameObject.SetActive(true);

        if (currenthp <= 0)
        {
            slider.gameObject.SetActive(false);
            currenthp = 0;
            Destroy(gameObject);
        }



    }

    void CanvasController()
    {
     
        slider.transform.position = (Offset + transform.position);

        if (currenthp == maxhp)
        {
            slider.gameObject.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
      

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(BulletController.rangedDamage);
        
            if (currenthp <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
     

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sword" && MeleeAttack.attacking == true)
        {
            TakeDamage(MeleeAttack.meleeDamage);
            Debug.Log("attack");
            if (currenthp <= 0)
            {
                Destroy(gameObject);
            }
        }
       
    }
}



