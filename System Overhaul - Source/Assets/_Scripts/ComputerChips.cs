using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComputerChips : MonoBehaviour
{
    public static float Computerchips = 0;
    public static Text ChipsText;
    public float rotateSpeed;


    // Start is called before the first frame update
    void Start()
    {

        ChipsText = GameObject.FindGameObjectWithTag("ChipsText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 90 * Time.deltaTime, 0, Space.Self);
        ChipsCheats();


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Computerchips += 1;
            ChipsText.text = "" + Computerchips;
            
            Destroy(gameObject);

        }

    }


    public void ChipsCheats()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.C))
        {
            Computerchips = 100;
            ChipsText.text = "" + Computerchips;
        }

    }
}

