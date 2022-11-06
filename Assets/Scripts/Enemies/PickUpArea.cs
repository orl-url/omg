using System.Collections.Generic;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpArea : MonoBehaviour
{
    internal List<Enemy> enemies = new List<Enemy>();
    private Enemy _otherGoblin;
    internal List<FixedJoint2D> fixedJoints = new List<FixedJoint2D>();

    private bool _rightHandBusy = false;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D pickUpAreaCollider;

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyDamageableArea enemy))
        {
            if (enemies.Count > 1) return;

            AddOtherEnemyToList(enemy);

            TakeGoblinsInHands();
        }
    }

    private void TakeGoblinsInHands()
    {
        if (_otherGoblin.enemyType != EnemyType.High && _otherGoblin.beUsedForThrow == false)
        {
            var rightSideThisGoblin = GetSideThisGoblin(1);
            var leftSideThisGoblin = GetSideThisGoblin(-1);
                
            TakeGoblinInHand(_otherGoblin, _rightHandBusy? leftSideThisGoblin: rightSideThisGoblin);

            AddFixedJoint();
        }
    }

    private void AddOtherEnemyToList(EnemyDamageableArea enemy)
    {
        _otherGoblin = enemy.GetComponentInParent<Enemy>();
        enemies.Add(_otherGoblin);
    }
    
    private void TakeGoblinInHand(Enemy otherEnemy, Vector3 sideThisGoblin)
    {
        otherEnemy.transform.position = pickUpAreaCollider.bounds.center + sideThisGoblin;
        otherEnemy.controller.enabled = false;
        _rightHandBusy = true;
    }
    
    private Vector3 GetSideThisGoblin(int sign)
    {
        var colliderSide = sign*pickUpAreaCollider.transform.right;
        return new Vector3(colliderSide.x, colliderSide.y, 0);
    }
    
    private void AddFixedJoint()
    {
        var fixedJoint = _otherGoblin.AddComponent<FixedJoint2D>();
        fixedJoint.connectedBody = rb;
        fixedJoints.Add(fixedJoint);
        _otherGoblin.beUsedForThrow = true;
    }
}
