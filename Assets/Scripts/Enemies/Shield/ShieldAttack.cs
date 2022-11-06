using Enemies;
using Interfaces;
using UnityEngine;

public class ShieldAttack : RangeHit
{
    [SerializeField] private Shield shield;
    [SerializeField] private InactiveShield inactiveShield;
    
    private InactiveShield _createdShield;
    
    private bool _isShieldDestroyed;

    
    private void FixedUpdate()
    {
        // Debug.Log("ShieldAttack - rangeDmg " + rangeDmg);
        _isShieldDestroyed = shield.isShieldDestroyed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out IBuiDamageable damageable))
        {
            gameObject.GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            CreateShield();
        }
    }

    private void CreateShield()
    {
        if (_isShieldDestroyed)
            return;
            
        shield.gameObject.SetActive(false);
            
        _createdShield = Instantiate(inactiveShield, shield.transform.position, Quaternion.identity);
        _createdShield.transform.SetParent(this.transform);
        _createdShield.Init(shield,GetComponentInParent<Enemy>(), castle, rangeDmg);
    }
}
