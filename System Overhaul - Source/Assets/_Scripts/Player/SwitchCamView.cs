using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchCamView : MonoBehaviour
{
    [SerializeField]
    //private PlayerInput playerInput;
    //[SerializeField]
    private int priorityBoostAmount = 10;
    [SerializeField]
    public Canvas thirdPersonCanvas;
    [SerializeField]
    public Canvas aimCanvas;

    private CinemachineVirtualCamera virtualCamera;
    //private InputAction aimAction;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        //aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        //aimAction.performed += _ => StartAim();
        //aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        //aimAction.performed -= _ => StartAim();
        //aimAction.canceled -= _ => CancelAim();
    }

    public void StartAim()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            virtualCamera.Priority += priorityBoostAmount;
            aimCanvas.enabled = true;
            thirdPersonCanvas.enabled = false;
        }
        else
        {
            virtualCamera.Priority -= priorityBoostAmount;
            aimCanvas.enabled = false;
            thirdPersonCanvas.enabled = true;
        }
    }

    /*public void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }
    */

    void Update()
    {
        StartAim();
    }
}
