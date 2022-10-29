using Common;
using Enemies;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BuildingsStats;

public class Building : MonoBehaviour, IBuildingType
{
    public IBuildingType.BuildingType buildingType;
        
    private float _hp, _damage, _attackRadius, _attackCooldown, _touchDamage, _touchDamageCooldown;
    private float _currentTime;
    
    public HealthBar healthBar;

    public void Init(AnyBuilding anyBuilding)
    {
        _hp = anyBuilding.hp;
        _damage = anyBuilding.arrowDamage;
        _attackCooldown = anyBuilding.attackCooldown;
        _attackRadius = anyBuilding.attackRadius;
        _touchDamage = anyBuilding.touchDamage;
        _touchDamageCooldown = anyBuilding.touchDamageCooldown;
        
        healthBar.maxHealth = _hp;
    }
    
    public IBuildingType.BuildingType SetType()
    {
        return buildingType;
    }
    
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

    public void DropBuildingOnScreen(Vector3 getMousePosition, int maxValue, int shopMask)
    {
        gameObject.SetActive(false);
        var hitInfo = Physics2D.Raycast(getMousePosition, Vector2.zero,maxValue, shopMask);
        // if (buildingType == (hitInfo.collider.GetComponent<Building>().buildingType));
        // {
        //     
        // }
        transform.position = hitInfo.collider.transform.position;
        gameObject.SetActive(true);
        Destroy(hitInfo.collider.gameObject);
    }
}


// public enum BuildingLevel
// {
//     Level1,
//     Level2,
//     Level3,
// }
