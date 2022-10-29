using Common;
using Enemies;
using Interfaces;
using UnityEngine;
using static BuildingsStats.AnyBuilding;

public class Castle : MonoBehaviour, IBuildingType
{
    private float _hp = BuildingsStats.AnyBuilding.Castle.hp;

    [SerializeField]
    private HealthBar healthBar;
    public IBuildingType.BuildingType buildingType;

    public IBuildingType.BuildingType SetType()
    {
        return buildingType;
    }

    private void Start()
    {
        healthBar.maxHealth = _hp;
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
