using Common;
using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BuildingsStats;

public class Building : MonoBehaviour
{
    private float _hp;
    private float _damage;
    private float _attackRadius;
    private float _attackCooldown;
    private float _touchDamage;
    private float _touchDamageCooldown;
    private float _currentTime;
    
    public HealthBar healthBar;

    private void Init(AnyBuilding anyBuilding)
    {
        _hp = anyBuilding.hp;
        _damage = anyBuilding.arrowDamage;
        _attackRadius = anyBuilding.attackRadius;

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
