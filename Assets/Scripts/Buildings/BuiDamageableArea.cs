using Interfaces;
using UnityEngine;

public class BuiDamageableArea : MonoBehaviour, IBuiDamageable
{
    [SerializeField] 
    private GameObject someBuilding;

    public void TakeDamage(float damage)
    {
        Debug.Log("buiTakeDmg");
        someBuilding.GetComponentInParent<Building>().TakeDamage(damage);
    }
}
