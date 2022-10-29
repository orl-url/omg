using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    private float _damage, _attackCooldown;

    private float _currentTime;

    public void Init(EnemiesStats.AnyGoblin anyGoblin)
    {
        _damage = anyGoblin.damage;
        _attackCooldown = anyGoblin.attackCooldown;
    }
    
    private void Start()
    {
        _currentTime = _attackCooldown;
    }
    
    private void Update()
    {
        if (_currentTime < 0f)
            return;
        
        _currentTime -= Time.deltaTime;
    }
    
    private void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("attackToBui");
        if (col.gameObject.TryGetComponent (out IBuiDamageable damageable) && _currentTime <= 0f)
        {
            damageable.TakeDamage(_damage);
            
            _currentTime = _attackCooldown;
        }
    }
}
