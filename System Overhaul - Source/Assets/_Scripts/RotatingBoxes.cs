using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    private GameObject box;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        box = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        box.transform.Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 20 * Time.deltaTime, Space.Self);
    }
}
