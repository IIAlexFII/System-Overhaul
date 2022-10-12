using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField]
    private GameObject aimImage;
    public GameObject player;
    public bool open;
    public GameObject UpgradePanels;
    public Text pressE;
    public Text upgrades;

    public Vector3 Offset;
    public Vector3 Offset2;

    // Start is called before the first frame update
    void Start()
    {
        pressE.gameObject.SetActive(false);
        upgrades.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        CanvasController();
        OpenPanel();

    }

    void CanvasController()
    {

        pressE.transform.position = (Offset + transform.position);
        upgrades.transform.position = (Offset2 + transform.position);

    }

    public void OpenPanel()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 6f)
        {
            pressE.gameObject.SetActive(true);
            upgrades.gameObject.SetActive(true);

            if ((Input.GetKeyDown(KeyCode.E)))
            {
                Cursor.lockState = CursorLockMode.None;
                open = !open;
                Cursor.lockState = CursorLockMode.Confined;
                if (open == false)
                {
                    aimImage.gameObject.SetActive(false);
                    UpgradePanels.SetActive(true);
                }
                else
                {
                    aimImage.gameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                    UpgradePanels.SetActive(false);
                }
            }




        }
        else
        {
            pressE.gameObject.SetActive(false);
            upgrades.gameObject.SetActive(false);
        }
    }
}
