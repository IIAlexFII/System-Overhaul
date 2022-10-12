using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public static Vector3 lastposition;
    public bool saved;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        saved = false;
        lastposition = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lastposition = other.transform.position;
            saved = true;

        }
    }
  

    
}
