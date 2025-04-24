using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

public class PlayerScript : MonoBehaviour
{
    Health health;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] GameObject playerShield;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject appleBullet;
    [SerializeField] private float bulletSpeed;

    private float bulletCooldown = 1f; // Renamed to bulletCooldown
    private float shieldDuration = 3.5f;
    [SerializeField] private float ShieldTimer;

    public bool isGrounded = true; // used in the animsys script
    private bool lookingRight;
    private bool lookingLeft;
    public bool walking;

    private Rigidbody2D rb;
    private Animator animator; // Declare Animator

    void Start()
    {
        ShieldTimer = shieldDuration; // Initialize ShieldTimer in Start
        FindFirstObjectByType<Health>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        lookingLeft = true;
        lookingRight = false;
    }

    void Update()
    {
        PlayerMovement();
        ShieldManager();
        PlayerShooting();
    }

    void PlayerMovement() // movement and sprite changes
    {
        if (Input.GetKey(KeyCode.A)) // move to the left
        {
            transform.position += new Vector3(-horizontalSpeed * Time.deltaTime, 0, 0);
            lookingLeft = true;
            lookingRight = false;
            walking = true;
        }

        if (Input.GetKey(KeyCode.D)) // move to the right
        {
            transform.position += new Vector3(horizontalSpeed * Time.deltaTime, 0, 0);
            lookingRight = true;
            lookingLeft = false;
            walking = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // jump, isgrounded is so you cannot jump while in the air
        {
            rb.AddForce(Vector3.up * verticalSpeed, ForceMode2D.Impulse);
            isGrounded = false; // Prevent double jumping :')
        }
        if (lookingLeft) // look to the left
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // ensure the sprite faces left
        }
        if (lookingRight) // look to the right
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // ensure the sprite faces right
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) // stop walking
        {
            walking = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // ground check
    {
        if (collision.gameObject.CompareTag("Ground")) // player collides with the ground
        {
            isGrounded = true; // player touches the ground is true, so she can jump again
        }

        if (collision.gameObject.CompareTag("enemy") && !playerShield.activeSelf)
        {
            health.TakeDamage(33.33f);
            health.playerRespawn();
            playerShield.SetActive(true); // Activate the shield
        }
    }

    private void ShieldManager()
    {
        if (playerShield.activeSelf) // Check if the shield is active
        {
            ShieldTimer -= Time.deltaTime; // Decrease the timer
            if (ShieldTimer <= 0)
            {
                playerShield.SetActive(false); // Disable the shield
                ShieldTimer = shieldDuration; // Reset the timer
            }
        }
    }
    private void PlayerShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(appleBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (lookingRight)
            {
                bulletRb.linearVelocity = new Vector2(bulletSpeed, 0); // Move bullet to the right
            }
            else if (lookingLeft)
            {
                bulletRb.linearVelocity = new Vector2(-bulletSpeed, 0); // Move bullet to the left
            }
        }
    }
}
