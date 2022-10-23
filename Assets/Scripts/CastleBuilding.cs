using Common;
using Enemies;
using UnityEngine;
using static BuildingsStats.AnyBuilding;

public class CastleBuilding : MonoBehaviour
{
    private float _hp = Castle.hp;
    private float _attackRadius = Castle.attackRadius;
    private float _attackCooldown = Castle.attackCooldown;
    private float _touchDamage = Castle.touchDamage;
    private float _touchDamageCooldown = Castle.touchDamageCooldown;
    private float _currentTime;

    public HealthBar healthBar;

    private void Start()
    {
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
