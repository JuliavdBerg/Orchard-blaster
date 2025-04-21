using UnityEngine;
using System.Collections.Generic;

public class AnimSys : MonoBehaviour
{
    PlayerScript PlayerScript;
    Animator animator; // Declare the animator variable

    void Start()
    {
        PlayerScript = FindFirstObjectByType<PlayerScript>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is grounded and not moving
        if (PlayerScript.isGrounded == true && PlayerScript.walking == false)
        {
            animator.Play("Idle");
        }
        if (PlayerScript.walking == true && PlayerScript.isGrounded == true)
        {
            animator.Play("Walk");
        }
        if (PlayerScript.isGrounded == false)
        {
            animator.Play("Jump");
        }
    }
}