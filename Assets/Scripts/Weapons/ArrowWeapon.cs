using System;
using System.Collections.Generic;
using Enemies;
using Interfaces;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowWeapon : MonoBehaviour
{
    [SerializeField] private ArrowsSpawner spawner;

    private readonly List<Enemy> _enemies = new List<Enemy>();
    private Enemy _currentEnemy;
    private float _timer;
    private float _attackCooldown;
    private IBuildingType.BuildingType _buildingType;

    private void Init(BuildingsStats.AnyBuilding anyBuilding)
    {
        _attackCooldown = anyBuilding.attackCooldown;
        _attackCooldown = BuildingsStats.AnyBuilding.Castle.attackCooldown;
    }
    
    
    private void Start()
    {
        _buildingType = GetComponentInParent<IBuildingType>().SetType();
        switch (_buildingType)
        {
            case IBuildingType.BuildingType.Castle:
            {
                Init(BuildingsStats.AnyBuilding.Castle);
                break;
            }
            case IBuildingType.BuildingType.ArcherTowerLevel1:
            {
                Init(BuildingsStats.AnyBuilding.ArcherTowerLvl1);
                break;
            }
        }
    }

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
        var enemy = GetCurrentEnemy();
        spawner.SpawnArrow(enemy.transform.position);
    }

    private Enemy GetCurrentEnemy()
    {
        return _enemies[Random.Range(0, _enemies.Count)];
    }
}
