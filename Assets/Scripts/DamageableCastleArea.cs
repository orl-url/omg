using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class DamageableCastleArea : MonoBehaviour, IDamageable
{
    [SerializeField] 
    private Castle castle;

    public void TakeDamage(float damage)
    {
        castle.TakeDamage(damage);
    }
}
