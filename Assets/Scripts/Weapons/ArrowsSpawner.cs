using UnityEngine;
using Weapons;

public class ArrowsSpawner : MonoBehaviour
{
    [SerializeField] internal Arrow arrow;
    [SerializeField] private Transform arrowShotPoint;

    public Arrow SpawnArrow(Vector3 target)
    {
        var direction = (target - transform.position).normalized;
        var rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);

        var createdArrow = Instantiate(arrow, arrowShotPoint.position, rotation);
        return createdArrow;
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
