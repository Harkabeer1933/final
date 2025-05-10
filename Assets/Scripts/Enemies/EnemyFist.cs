using UnityEngine;

public class EnemyFist : MonoBehaviour
{
    [SerializeField] LayerMask hurtLayer; // Layers that can be hurt
    [SerializeField] float hurtVal; // Damage value
    [SerializeField] float knockVal; // Knockback force

    void OnTriggerEnter(Collider coll)
    {
        //  Fix: Correct way to check if colliding object's layer is in hurtLayer
        if (((1 << coll.gameObject.layer) & hurtLayer) != 0)
        {
            // Try to apply damage if the object implements IHurtable
            if (coll.gameObject.TryGetComponent(out IHurtable hurtable))
            {
                hurtable.Hurt(hurtVal);
            }

            // Try to apply knockback if the object implements IKnockable
            if (coll.gameObject.TryGetComponent(out IKnockable knockable))
            {
                Vector3 knockDirection = (coll.transform.position - transform.position).normalized * knockVal;
                knockDirection.y = 0f; // Prevent unnecessary vertical knockback
                knockable.Knock(knockDirection);
            }
        }
    }

}
