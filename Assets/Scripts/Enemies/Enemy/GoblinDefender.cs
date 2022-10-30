using UnityEngine;

namespace Enemies
{
    public class GoblinDefender : Enemy
    {
        private void Awake()
        {
            Init(EnemiesStats.AnyGoblin.GoblinDefender);
        }
    }
}