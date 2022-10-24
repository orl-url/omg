using Common;
using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BuildingsStats;

public class Building : MonoBehaviour
{
    public BuildingType buildingType;
        
    private float _hp;
    private float _damage;
    private float _attackRadius;
    private float _attackCooldown;
    private float _touchDamage;
    private float _touchDamageCooldown;
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

    public void DropBuilding(Building createdObject, Vector3 getMousePosition, int maxValue, int shopMask)
    {
        createdObject.gameObject.SetActive(false);
        var hitInfo = Physics2D.Raycast(getMousePosition, Vector2.zero,maxValue, shopMask);
        createdObject.transform.position = hitInfo.collider.transform.position;
        createdObject.gameObject.SetActive(true);

        // Debug.Log("новые координаты стены  " + _createdObject.transform.position);
        // Debug.Log("имя объекта к которому прикрепится стена  " + hitInfo.collider.name);
    }
}
public enum BuildingType
{
    WoodenWall,
    StoneWall,
}
