using UnityEngine;
using System.Collections.Generic;

public class AnimSys : MonoBehaviour
{
    PlayerScript PlayerScript;
    Animator animator; // Declare the animator variable

    void Start()
    {
        PlayerScript = FindObjectOfType<PlayerScript>();
        if (PlayerScript == null)
        {
            Debug.LogError("PlayerScript not found!");
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found!");
        }
    }

    void Update()
    {
        // Check if the player is grounded and not moving
        if (PlayerScript.isGrounded == true && PlayerScript.walking == false)
        {
            animator.Play("idle");
            Debug.Log("Player is idle");
        }

        if (PlayerScript.walking == true)
        {
            animator.Play("walk");
            Debug.Log("Player is walking");
        }
    }
}