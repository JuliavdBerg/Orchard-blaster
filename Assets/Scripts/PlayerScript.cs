using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;

    public bool isGrounded = true; // used in the animsys script
    private bool lookingRight;
    private bool lookingLeft;
    public bool walking;

    public Rigidbody2D rb;
    private Animator animator; // Declare Animator


 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Initialize Animator
        lookingLeft = false;
        lookingRight = false;

    }

    void Update()
    {
        PlayerMovement();
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
        if (!collision.gameObject.CompareTag("Ground")) // player collides with the ground
        {
            isGrounded = false; // player touches the ground is true, so she can jump again
        }
        else
        {
            isGrounded = true;
        }
    }
}
