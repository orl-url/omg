using Enemies;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    public Enemy enemyPref;
    public int count;
    public float cooldown;
}
