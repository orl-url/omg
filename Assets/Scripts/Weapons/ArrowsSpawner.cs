using UnityEngine;
using Weapons;

public class ArrowsSpawner : MonoBehaviour
{
    [SerializeField] private Arrow arrow;
    [SerializeField] private Transform arrowShotPoint;

    public void SpawnArrow(Vector3 target)
    {
        var direction = (target - transform.position).normalized;
        var rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);

        Instantiate(arrow, arrowShotPoint.position, rotation);
    }

    // private void Init(AnyBuilding anyBuilding)

    // {

    //     _cooldown = anyBuilding.attackCooldown;

    //     gameObject.GetComponent<CircleCollider2D>().radius = anyBuilding.attackRadius;

    // }

    
    // public void CreateArrowWave()
    // {
    //     for (var i = 0; i < 12; i++)
    //     {
    //         var rotation = Quaternion.Euler(0, 0, 30 * i);
    //         Instantiate(arrow, arrowShotPoint.position, rotation);
    //     }
    // }
}
