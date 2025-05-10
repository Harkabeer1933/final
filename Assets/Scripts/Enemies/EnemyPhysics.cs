using UnityEngine;

public class EnemyPhysics : MonoBehaviour, IKnockable
{
    [SerializeField] float mass;    // Enemy's mass, affects force application
    [SerializeField] float drag;    // General drag for slowing down acceleration
    [SerializeField] float dragVel; // Velocity drag (reduces movement over time)

    Vector3 acceleration = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    // Apply physics calculations every frame
    public void processPhysics()
    {
        enemyMove();
    }

    // Applies acceleration, velocity, and movement logic
    void enemyMove()
    {
        acceleration *= 1 - drag; // Apply drag to acceleration
        velocity += acceleration * Time.fixedDeltaTime; // Integrate acceleration into velocity
        velocity *= 1 - dragVel; // Apply drag to velocity
        transform.localPosition += velocity * Time.fixedDeltaTime; // Apply movement
    }

    // Adds acceleration force
    void applyAcceleration(Vector3 a)
    {
        acceleration += a;
    }

    // Applies force relative to mass
    void applyForce(Vector3 f)
    {
        applyAcceleration(f / mass);
    }

    // Knockback mechanic (pushed backward)
    public void Knock(Vector3 f)
    {
        f.y = 0f; // Prevent vertical knockback
        applyForce(f);
    }
}
