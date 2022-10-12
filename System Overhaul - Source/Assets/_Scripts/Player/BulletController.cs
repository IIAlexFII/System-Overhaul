using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletHole;
 
    private float speed = 50f;
    private float timeToDestroy = 3f;

    public static float rangedDamage = 10f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }


    private void Start()
    {
     
    }
    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {

            Destroy(gameObject);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        GameObject bh = Instantiate(bulletHole, contact.point + contact.normal * 0.0001f, Quaternion.LookRotation(contact.normal));
        Destroy(bh, 3f);
        Destroy(gameObject);







    }





}
