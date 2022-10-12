using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl : MonoBehaviour
{
    public Transform[] pictures;
    public static bool youwin;

    // Start is called before the first frame update
    void Start()
    {
        youwin = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void CheckifSolved()
    {
        if (pictures[0].localEulerAngles.z == 0 && pictures[1].localEulerAngles.z == 0
        && pictures[2].localEulerAngles.z == 0 && pictures[3].localEulerAngles.z == 0
        && pictures[4].localEulerAngles.z == 0 && pictures[5].localEulerAngles.z == 0
        && pictures[6].localEulerAngles.z == 0 )
        {
            youwin = true;
            Debug.Log("Solved");
        }
    }
}
