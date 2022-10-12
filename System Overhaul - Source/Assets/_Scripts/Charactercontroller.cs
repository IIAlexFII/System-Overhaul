using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Charactercontroller : MonoBehaviour
{
    private CharacterController ch;
    private Transform cameraTransform;
    private Animator animator;

    public Vector3 currentmovement;
    public Vector3 playerVelocity;
    public Vector3 velocity;
    public Button Dashbutton;
    public float speed = 3;
    public float DashSpeed;
    public float CooldownDecreasingDash;
    public float DashTime;
    public Text DashUpgradeText;
    public Text DashCooldown;
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
    int jumpAnimation;

    [SerializeField]
    private float animationPlayTimer = 0.15f;

    private Health hp;
    private Image dash;
    public GameObject[] rangedEnemy;
    public GameObject[] meleeEnemy;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        jumpAnimation = Animator.StringToHash("Pistol Jump");
    }


    void Start()
    {
        dash = GameObject.FindGameObjectWithTag("Dash Button").GetComponent<Image>();
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        rangedEnemy = GameObject.FindGameObjectsWithTag("enemy");
        meleeEnemy = GameObject.FindGameObjectsWithTag("enemy 2");
        ch = GetComponent<CharacterController>();
        CooldownDecreasingDash = dashCD;
        cameraTransform = Camera.main.transform;
        DashCooldown.gameObject.SetActive(false);
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
        animator.SetFloat("MoveX", Horizontal);
        animator.SetFloat("MoveZ", Vertical);

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y = jumpforce;
            animator.CrossFade(jumpAnimation, animationPlayTimer); ;

            Debug.Log("Jump");
        }

        if (playerVelocity.y >= -0.2)
        {
            playerVelocity.y += gravity * 6 * (Time.deltaTime);
        }
        if (playerVelocity.y < -0.2)
        {
            playerVelocity.y += gravity * 12 * (Time.deltaTime);
        }

        CooldownDecreasingDash = dashCD;

        ch.Move(playerVelocity * Time.deltaTime);

        dashCD -= Time.deltaTime;
        DashCooldown.text = "" + (int)CooldownDecreasingDash;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (dashCD <= 0)
            {
                CooldownDecreasingDash -= Time.deltaTime;
                StartCoroutine(Dash());
            }
            dashing = false;
        }
        //Dash Image transparency

        if (dashCD <= 0)
        {
            DashCooldown.gameObject.SetActive(false);
            dash.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            float alpha = DashTime / dashCD;
            if (alpha > 1f)
            {
                alpha = 1f;
            }
            dash.color = new Color(1f, 1f, 1f, alpha * 0.5f + 0.5f);
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

        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        WeaponSwitch();
        KillEnemiesCheats();
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + DashTime && dashing == false)
        {
            ch.Move(currentmovement * DashSpeed * Time.deltaTime);
            DashCooldown.gameObject.SetActive(true);
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
            if (Input.GetKeyDown(KeyCode.Mouse2) && weaponSwitchTimer > 0.5f)
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
            DashUpgradeText.text = "MAX";
            Destroy(Dashbutton);
        }
    }

    public void KillEnemiesCheats()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.V))
        {
            foreach (GameObject Renemies in rangedEnemy)
            {
                Destroy(Renemies);
            }
            foreach (GameObject Menemies in meleeEnemy)
            {
                Destroy(Menemies);
            }
        }
    }
}
