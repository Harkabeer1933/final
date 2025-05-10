using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
    }
}
