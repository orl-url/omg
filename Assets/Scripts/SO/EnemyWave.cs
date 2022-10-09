using System.Collections.Generic;
using Enemies;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    public List<string> step; 
    public Enemy enemyPref;
    public int count;
    public float cooldown;
}
