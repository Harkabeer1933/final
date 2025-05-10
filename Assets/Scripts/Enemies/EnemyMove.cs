using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float maxAccel;
    [SerializeField] float maxVel;
    [SerializeField] float turnVel;

    private Vector3 velocity;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Get Animator
    }

    public void processMove(Vector3 target)
    {
        Vector3 targetDir = (target - transform.position).normalized;
        enemyMove(targetDir);
    }

    void enemyMove(Vector3 dir)
    {
        // Rotate towards the movement direction
        transform.forward = Vector3.RotateTowards(transform.forward, dir, turnVel, 0f);

        // Calculate movement velocity
        Vector3 desiredVel = dir * maxVel;
        float maxVelDelta = maxAccel * Time.fixedDeltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVel.x, maxVelDelta);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVel.y, maxVelDelta);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVel.z, maxVelDelta);

        // Apply movement
        Vector3 disp = velocity * Time.fixedDeltaTime;
        transform.localPosition += disp;

        // 🔥 Animation Handling - Walking / Idle
        bool isWalking = velocity.magnitude > 0.1f;
        animator.SetBool("isWalking", isWalking);
    }



}
