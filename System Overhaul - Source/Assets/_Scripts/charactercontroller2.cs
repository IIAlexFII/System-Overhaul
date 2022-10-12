using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class charactercontroller2 : MonoBehaviour
{
    private CharacterController ch;
    private Transform cameraTransform;


    public Vector3 currentmovement;
    private Vector3 playerVelocity;
    public Vector3 velocity;
    public Button Dashbutton;
    public float speed = 3;
    public float DashSpeed;
    public float DashTime;
    public float dashCD;
    public float weaponSwitchTimer = 0;
    public float jumpforce;
    public float rotationSpeed = 0.8f;
    float gravity = -9.8f;
    public bool dashing = false;
    public float crouchingHeight = 1.25f;
    public float standingHeight = 2f;
    public bool crouching = false;
    private bool groundedPlayer;
    public bool isRangedWeapon = true;
    public bool attacking = false;


    private Health hp;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        ch = GetComponent<CharacterController>();

        cameraTransform = Camera.main.transform;

        isRangedWeapon = true;
        dashing = false;
        //Deactivate Melee Object and Script
        GetComponent<PlayerMeleeAttack>().sword.SetActive(!isRangedWeapon);
        GetComponent<PlayerMeleeAttack>().enabled = !isRangedWeapon;

        GetComponent<RangedAttack>().Gun.SetActive(isRangedWeapon);
        GetComponent<RangedAttack>().enabled = isRangedWeapon;
    }

    void Update()
    {

        groundedPlayer = ch.isGrounded;
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        currentmovement.z = Vertical * speed;
        currentmovement.x = Horizontal * speed;



        currentmovement = currentmovement.x * cameraTransform.right.normalized + currentmovement.z * cameraTransform.forward.normalized;
        currentmovement.y = 0;
        ch.Move(currentmovement * Time.deltaTime);



        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;

        }

        /*if(playerVelocity.y > 0 && !ch.isGrounded)
        {
            playerVelocity.y += gravity * 1.5f * Time.deltaTime;
        }*/

        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y = jumpforce;
            ch.Move(playerVelocity * Time.deltaTime);
            Debug.Log("Jump");
            //playerVelocity.y += Mathf.Sqrt(jumpforce * -3.0f * gravity);
            //ch.Move(playerVelocity * Time.deltaTime);
        }

        playerVelocity.y += gravity * (5 * Time.deltaTime);
        ch.Move(playerVelocity * Time.deltaTime);


        dashCD -= Time.deltaTime;

        if (Input.GetButton("Dash"))
        {
            if (dashCD <= 0)
            {
                StartCoroutine(Dash());
            }
            dashing = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouching = true;

        }
        else
        {
            crouching = false;
        }


        if (crouching == true)
        {
            ch.height = crouchingHeight;

        }
        else
        {
            ch.height = standingHeight;
        }




        if (Input.GetButton("Sprint"))
        {
            dashing = true;
            speed = 16;
        }
        else
        {
            speed = 10;
        }


        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        WeaponSwitch();

    }
    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + DashTime && dashing == false)
        {
            ch.Move(currentmovement * DashSpeed * Time.deltaTime);
            dashCD = 3;
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            dashing = true;
            yield return null;
        }
        gameObject.GetComponent<TrailRenderer>().enabled = false;
    }

    void WeaponSwitch()
    {
        weaponSwitchTimer += Time.deltaTime;

        if (!GetComponent<PlayerMeleeAttack>().attacking)
        {

            if (Input.GetButtonDown("Switch Weapon") && weaponSwitchTimer > 0.5f)
            {
                isRangedWeapon = !isRangedWeapon;

                //GetComponent<PlayerMeleeAttack>().canUseSword = false;

                GetComponent<PlayerMeleeAttack>().sword.SetActive(!isRangedWeapon);
                GetComponent<PlayerMeleeAttack>().enabled = !isRangedWeapon;

                GetComponent<RangedAttack>().Gun.SetActive(isRangedWeapon);
                GetComponent<RangedAttack>().enabled = isRangedWeapon;
                weaponSwitchTimer = 0f;

                Debug.Log("Switch Weapon");

            }
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pill")
        {

            hp.TakeDamage(10f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Pill 2")
        {
            hp.Heal(10f);
            Destroy(other.gameObject);
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Lava")
        {

            hp.TakeDamage(1f);

        }
    }

    public void DashUpgrade()
    {
        if (ComputerChips.Computerchips >= 5)
        {
            DashSpeed = 5;
            ComputerChips.Computerchips -= 5;
            ComputerChips.ChipsText.text = "" + ComputerChips.Computerchips;
            Destroy(Dashbutton);
        }
    }





}
