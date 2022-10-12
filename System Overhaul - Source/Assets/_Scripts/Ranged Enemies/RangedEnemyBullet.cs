using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBullet : MonoBehaviour
{
    private Health health;

    public float speed = 50f;
    private float timeToDestroy = 3f;

    private float reBulletDamage = 10; //re is ranged enemy
    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void Start()
    {
        health = FindObjectOfType<Health>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health.TakeDamage(reBulletDamage);
            Destroy(gameObject);
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            health.TakeDamage(reBulletDamage);
        }
        Destroy(gameObject);
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            health.TakeDamage(reBulletDamage);
            Destroy(gameObject);
        }
    }*/
}
