using System.Collections;
using System.Collections.Generic;
using Common;
using Enemies;
using UnityEngine;
using static BuildingsStats;

public class CastleBuilding : MonoBehaviour
{
    private float _hp;
    private float _damage;
    private float _attackRadius;
    private float _attackCooldown;
    private float _touchDamage;
    private float _touchDamageCooldown;
    private float _currentTime;

    // public AttackBonuses attackBonuses;

    public HealthBar healthBar;

    private void Init(AnyBuilding castle)
    {
        _hp = castle.hp;
        _damage = castle.arrowDamage;
        _attackRadius = castle.attackRadius;
        _touchDamage = castle.touchDamage;
        _touchDamageCooldown = castle.touchDamageCooldown;
    }

    
    private void Start()
    {
        this.Init(AnyBuilding.Castle);
        _currentTime = _touchDamageCooldown;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if (_currentTime <= 0f && col.gameObject.TryGetComponent (out Enemy enemy))
        {
            enemy.TakeDamage(_touchDamage);
            _currentTime = _touchDamageCooldown;
        }
    }
    
    public void TakeDamage(float enemyDamage)
    {
        _hp -= enemyDamage;
        healthBar.HealthUpdate(_hp);
        if (_hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
