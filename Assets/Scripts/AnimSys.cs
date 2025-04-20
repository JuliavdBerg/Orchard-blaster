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
            Debug.Log("Player is idle");
        }
        if (PlayerScript.walking == true && PlayerScript.isGrounded == true)
        {
            animator.Play("Walk");
            Debug.Log("Player is walking");
        }
        if (PlayerScript.isGrounded == false)
        {
            animator.Play("Jump");
            Debug.Log("Player is jumping");
        }
    }
}