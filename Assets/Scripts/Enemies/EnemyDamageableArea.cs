using Enemies;
using Interfaces;
using UnityEngine;

public class EnemyDamageableArea : MonoBehaviour, IEnemyDamageable
{
    [SerializeField] 
    private GameObject someEnemy;

    public void TakeDamage(float damage)
    {
        Debug.Log("takedmg");
        someEnemy.GetComponentInParent<LittleGoblin>().TakeDamage(damage);
    }
    
    
}
