using Enemies;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    public Enemy EnemyPref;
    public int Count;
    public float Cooldown;
}
