using Interfaces;
using UnityEngine;

public class BuiDamageableArea : MonoBehaviour, IBuiDamageable
{
    [SerializeField] 
    private GameObject someBuilding;

    public void TakeDamage(float damage)
    {
        someBuilding.GetComponentInParent<Building>().TakeDamage(damage);
    }
}
