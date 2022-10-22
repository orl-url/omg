using System;
using Enemies;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static BuildingsStats;
using static BonusesStats;

public class ArrowsSpawner : MonoBehaviour
{
    private float _cooldown;
    
    private float _currentTime = 1f;

    public CardManager cardManager;
    public GameObject arrow;
    public Transform arrowShotPoint;

    private void Init(AnyBuilding castle)
    {
        _cooldown = castle.attackCooldown;
        gameObject.GetComponent<CircleCollider2D>().radius = castle.attackRadius;
    }

    private void Start()
    {
        this.Init(AnyBuilding.Castle);
        _currentTime = _cooldown;
        this.cardManager.Init(this);

    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
    }

    // Arrow spawn.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_currentTime >= 0)
            return;

        if (other.gameObject.TryGetComponent(out Enemy _))
        {
            var target = other.transform.position;
            SpawnArrow(target);
            
            _currentTime = _cooldown;
        }
    }

    private void SpawnArrow(Vector2 target)
    {
        var direction = (target - (Vector2)transform.position).normalized;
        var rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        Instantiate(arrow, arrowShotPoint.position, rotation);
    }
}
