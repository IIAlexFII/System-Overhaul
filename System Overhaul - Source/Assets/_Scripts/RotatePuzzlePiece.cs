using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzlePiece : MonoBehaviour
{
    [SerializeField]
    private PuzzleControl puzzlecontrol;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void OnMouseDown()
    {
        if (PuzzleControl.youwin == false)
        {
            transform.Rotate(0f, 0f, 90f);
            puzzlecontrol.CheckifSolved();
        }


    }
}
