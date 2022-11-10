using UnityEngine;
using Weapons;

public class ArrowsSpawner : MonoBehaviour
{
    [SerializeField] internal Arrow arrow;
    [SerializeField] private Transform arrowShotPoint;

    public Arrow Spawn(Vector3 target, float damage)
    {
        var direction = SetDirection(target);
        var rotation = SetRotation(direction);

        var createdArrow = Instantiate(arrow, arrowShotPoint.position, rotation);
        createdArrow.Init(damage, gameObject.layer);
        return createdArrow;
    }

    private Vector3 SetDirection(Vector3 target)
    {
        var direction = (target - transform.position).normalized;
        return direction;
    }

    private Quaternion SetRotation(Vector3 direction)
    {
        var rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        return rotation;
    }
    
    
    // public void CreateArrowWave()
    // {
    //     for (var i = 0; i < 12; i++)
    //     {
    //         var rotation = Quaternion.Euler(0, 0, 30 * i);
    //         Instantiate(arrow, arrowShotPoint.position, rotation);
    //     }
    // }
}
