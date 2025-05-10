using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] float attackTime;
    [SerializeField] GameObject fist;

    private Animator animator;
    private float attackTimer = 0f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Get Animator
    }

    void FixedUpdate()
    {
        attackTimer = Mathf.Clamp(attackTimer - Time.fixedDeltaTime, 0f, attackTime);
    }

    public void initAttack()
    {
        stopAttack();
    }

    public void processAttack(Vector3 target)
    {
        if (isAttacking) return; 

        stopAttack();
        if (isInRange(target))
        {
            attack();
        }
    }

    public bool isInRange(Vector3 target)
    {
        return (transform.position - target).magnitude < attackRange;
    }

    //  FIX: Properly define the "isAttacking" property
    public bool isAttacking
    {
        get { return attackTimer > 0f; }
    }

    public void attack()
    {
        attackTimer = attackTime;
        fist.SetActive(true);
        animator.SetTrigger("Attack"); //  Play attack animation
    }

    // Called via Animation Event
    public void stopAttack()
    {
        fist.SetActive(false); //  Ensure fist deactivates after attack
    }
}
