using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puzzle : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    public GameObject door;
    public bool open;
    public Text pressE;
    [SerializeField]
    private GameObject aimImage;
    [SerializeField]
    private Text Solved;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        CanvasController();

        if (Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            pressE.gameObject.SetActive(true);

            if ((Input.GetKeyDown(KeyCode.E)))
            {

                open = !open;

                if (open == false)
                {
                    aimImage.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Confined;
                    panel.SetActive(true);



                }
                else
                {
                    aimImage.gameObject.SetActive(true);
                    panel.SetActive(false);
                }
            }




        }
        else
        {
            pressE.gameObject.SetActive(false);

        }

        if (open == false)
        {

            if (PuzzleControl.youwin)
            {
                door.SetActive(false);
                Solved.gameObject.SetActive(true);
                Invoke("RemovePanel", 2f);
            }
            else
            {
                Solved.gameObject.SetActive(false);

            }

        }

    }

    public void RemovePanel()
    {
        panel.SetActive(false);
        aimImage.gameObject.SetActive(true);

    }

    void CanvasController()
    {

        pressE.transform.position = (Offset + transform.position);

    }
}