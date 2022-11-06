using Enemies;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowArea : MonoBehaviour
{
    private FixedJoint2D _fixedJoint2D;
    private Enemy _enemyGoblin;

    [SerializeField] private Collider2D throwAreaCollider2D;
    [SerializeField] private Rigidbody2D rb;

    // public Controller controller;


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
        if (col.TryGetComponent(out EnemyDamageableArea enemy))
        {
            _enemyGoblin = enemy.GetComponentInParent<Enemy>();
            
            if (_enemyGoblin.beUsedForThrow == false)
            {
                var otherEnemy = GetEnemyScript(col);

                var rightSideThisGoblin = new Vector3(throwAreaCollider2D.transform.right.x, throwAreaCollider2D.transform.right.y, 0);
                otherEnemy.transform.position = throwAreaCollider2D.bounds.center + rightSideThisGoblin;

                otherEnemy.controller.enabled = false;
                
                AddFixedJoint();
            }
        }

        else if (col.TryGetComponent(out BuiDamageableArea building))
        {
            RemoveFixedJoint(_enemyGoblin);
            var some = _enemyGoblin.GetComponent<Rigidbody2D>();
                some.AddForce((transform.up * (-7000)), ForceMode2D.Impulse);
                // some.MovePosition(_enemyGoblin.transform.position + transform.up *(-10000f));
            Debug.Log("AfterImpulse");
        }
    }

    private Enemy GetEnemyScript(Collider2D collider2D)
    {
        return collider2D.GetComponentInParent<Enemy>();
    }
    
    private void AddFixedJoint()
    {
        _fixedJoint2D = _enemyGoblin.AddComponent<FixedJoint2D>();
        _fixedJoint2D.connectedBody = rb;
        _enemyGoblin.beUsedForThrow = true;
    }
   
    
    private void RemoveFixedJoint(Enemy enemy)
    {
        Destroy(_fixedJoint2D);
    }
}
