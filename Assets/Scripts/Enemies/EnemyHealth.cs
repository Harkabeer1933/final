using UnityEngine;
using System.Collections; // Required for coroutine

public class EnemyHealth : MonoBehaviour, IHurtable
{
    [SerializeField] float healthStart; // Initial health value
    [SerializeField] float deathDelay = 3f; // Delay before destroying the zombie

    private Animator animator; // Reference to Animator
    private bool isDead = false; // Prevent multiple death triggers

    public float Health { get; private set; } // Public health getter, private setter

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Get Animator component
        initHealth(); // Initialize health on start
    }

    // Initializes health value
    public void initHealth()
    {
        Health = healthStart;
        isDead = false;
    }

    // Reduces health when damaged
    public void Hurt(float val)
    {
        if (isDead) return; // Prevent additional damage after death

        Health -= val;
        if (Health <= 0)
        {
            Die(); // Call death handling function
        }
    }

    // Handles zombie death
    void Die()
    {
        if (isDead) return; // Prevent multiple calls

        isDead = true; // Mark as dead
        animator.SetTrigger("Die"); //  Play death animation
        StartCoroutine(DestroyAfterDelay()); // Wait before destroying
    }

    // Coroutine to wait before destroying the object
    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(deathDelay); //  Wait for 3 seconds
        Destroy(gameObject); // 💥 Destroy zombie
    }
}
