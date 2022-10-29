using Common;
using UnityEngine;
using static BuildingsStats;

public class Building : MonoBehaviour
{
    public BuildingType type;

    private float _hp;
    
    [SerializeField]
    protected HealthBar healthBar;

    protected void Init(AnyBuilding anyBuilding)
    {
        _hp = anyBuilding.hp;
        
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

    // public void DropBuildingOnScreen(Vector3 getMousePosition, int maxValue, int shopMask)
    // {
    //     gameObject.SetActive(false);
    //     var hitInfo = Physics2D.Raycast(getMousePosition, Vector2.zero,maxValue, shopMask);
    //     // if (buildingType == (hitInfo.collider.GetComponent<Building>().buildingType));
    //     // {
    //     //     
    //     // }
    //     transform.position = hitInfo.collider.transform.position;
    //     gameObject.SetActive(true);
    //     Destroy(hitInfo.collider.gameObject);
    }


