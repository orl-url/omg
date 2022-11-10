using System.Collections.Generic;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowWeapon : MonoBehaviour
{
    [SerializeField] private ArrowsSpawner arrowsSpawner;

    private readonly List<Enemy> _enemies = new List<Enemy>();
    private Enemy _currentEnemy;
    private float _timer, _attackCooldown;
    private BuildingType _buildingType;
    private BuildingsStats.AnyBuilding _anyBuilding;

    public void Init(BuildingsStats.AnyBuilding anyBuilding)
    {
        _anyBuilding = anyBuilding;
        _attackCooldown = anyBuilding.attackCooldown;
        
        SetAttackRadius(GetComponent<CircleCollider2D>(), anyBuilding);
        // SetArrowParameters(anyBuilding);
    }

    private void SetAttackRadius(CircleCollider2D attackArea, BuildingsStats.AnyBuilding anyBuilding)
    {
        attackArea.radius = anyBuilding.attackRadius;
    }

    // private void SetArrowParameters(BuildingsStats.AnyBuilding anyBuilding)
    // {
    //     spawner.Init(anyBuilding);
    // }
    

    private void OnEnable()
    {
        Enemy.onDied += RemoveTargetedEnemy;
    }

    private void OnDisable()
    {
        Enemy.onDied -= RemoveTargetedEnemy;
    }

    private void Update()
    {
        if (_enemies.Count == 0)
            return;

        _timer += Time.deltaTime;
        if (_timer > _attackCooldown)
        {
            _timer -= _attackCooldown;
            Shoot();
        }
    }

    public void AddTargetedEnemy(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
            return;
        
        _enemies.Add(enemy);
    }

    private void RemoveTargetedEnemy(Enemy enemy)
    {
        if (_enemies.Contains(enemy) == false)
            return;

        _enemies.Remove(enemy);
    }

    private void Shoot()
    {
        // Добавить свич.
        var enemy = GetCurrentEnemy();
        var createdArrow = arrowsSpawner.Spawn(enemy.transform.position, BuildingsStats.AnyBuilding.Castle.arrowDamage);
    }

    private Enemy GetCurrentEnemy()
    {
        return _enemies[Random.Range(0, _enemies.Count)];
    }
}
