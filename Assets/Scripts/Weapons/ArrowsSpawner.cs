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
    private readonly float _arrowWaveCooldown = arrowWaveCooldown ;
    private float _currentArrowWaveTime = 1f;

    // public CardManager cardManager;
    public GameObject arrow;
    public Transform arrowShotPoint;

    public void Init(AnyBuilding anyBuilding)
    {
        _cooldown = anyBuilding.attackCooldown;
        gameObject.GetComponent<CircleCollider2D>().radius = anyBuilding.attackRadius;
    }

    private void Start()
    {
        if (gameObject.name == "CastleDamageArea")
        {
            Init(AnyBuilding.Castle);
        }
        _currentTime = _cooldown;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        
        _currentArrowWaveTime -= Time.deltaTime;
        
        if (gameObject.name == "CastleDamageArea" && flagCreateArrowWave == true && _currentArrowWaveTime <= 0)
        {
            this.CreateArrowWave();
            _currentArrowWaveTime = _arrowWaveCooldown;
        }
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
    
    public void CreateArrowWave()
    {
        var i = 0;
        while (i < 12)
        {
            var rotation = Quaternion.Euler(0, 0, 30 * i);
            Instantiate(arrow, arrowShotPoint.position, rotation);
            i++;
        }
    }
}
