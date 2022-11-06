using Enemies;
using UnityEngine;

public class ThrowHitArea : MonoBehaviour
{
    [SerializeField] private PickUpArea pickUpArea;

    private void OnEnable()
    {
        Enemy.onDied += RemoveFixedJoint;
    }
    
    private void OnDisable()
    {
        Enemy.onDied -= RemoveFixedJoint;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out BuiDamageableArea _))
        {
            foreach (var goblin in pickUpArea.enemies)
            {
                RemoveFixedJoint(goblin);
                AddImpulseToOtherGoblin(goblin);
            }
        }
    }
    
    private void AddImpulseToOtherGoblin(Enemy goblin)
    {
        var enemyRb = goblin.GetComponent<Rigidbody2D>();
        enemyRb.AddForce((transform.up * (-10)), ForceMode2D.Impulse);
    }
    
    private void RemoveFixedJoint(Enemy enemy)
    {
        foreach (var fixedJoint in pickUpArea.fixedJoints)
        {
            Destroy(fixedJoint);
        }
    }
}
