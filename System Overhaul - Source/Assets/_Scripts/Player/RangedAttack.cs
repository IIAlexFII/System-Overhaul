using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedAttack : MonoBehaviour
{
    private Transform cameraTransform;

    public SwitchCamView switchCamView;

    public GameObject Gun;
    private float shootimer;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private float bulletDespawnDistance = 25f;
    [SerializeField]
    private float spreadValue = 0.1f;
    [SerializeField]
    private float FireRatePerSecond = 4f;
    [SerializeField]
    private Button RangedDamageButton;



    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void shootGun()
    {
        shootimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && shootimer >= (1/FireRatePerSecond))
        {
           
            RaycastHit hit;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            Vector3 shootDirection = cameraTransform.forward;

            shootDirection.x += Random.Range(-spreadValue, spreadValue);
            shootDirection.y += Random.Range(-spreadValue, spreadValue);
            shootDirection.z += Random.Range(-spreadValue, spreadValue);
            //shootDirection.z = transform.position.z;
            //bool raycast = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity);

            if (Physics.Raycast(cameraTransform.position, shootDirection.normalized, out hit, Mathf.Infinity))        // && switchCamView.aimCanvas.enabled == true)
            {
                bulletController.target = hit.point;
                bulletController.hit = true;
                shootimer = 0;
            }
            else
            {
                bulletController.target = cameraTransform.position + cameraTransform.forward * bulletDespawnDistance;
                bulletController.hit = false;
                shootimer = 0;
            }
        }
    }

    void Update()
    {
        shootGun();
      
    }

    public void DamageUpgrade()
    {
        if (ComputerChips.Computerchips >= 3)
        {
            BulletController.rangedDamage = 15;
            ComputerChips.Computerchips -= 3;
            ComputerChips.ChipsText.text = "" + ComputerChips.Computerchips;
            Destroy(RangedDamageButton);
        }
    }
}
