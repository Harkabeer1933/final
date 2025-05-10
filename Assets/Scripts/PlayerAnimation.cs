using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator; // Reference to Animator

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Get Animator component
    }

    void Update()
    {
        HandleAnimations();
    }

    void HandleAnimations()
    {
        // If shooting, play shooting animation
        if (Input.GetButton("Fire1")) // Change this based on your shooting system
        {
            animator.SetBool("isShooting", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isShooting", false);
            animator.SetBool("isIdle", true);
        }
    }

}
