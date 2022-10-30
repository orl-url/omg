using UnityEngine;

namespace Enemies
{
    public class BossGoblin : Enemy
    {
        private void Awake()
        {
            Init(EnemiesStats.AnyGoblin.BossGoblin);
        }
    }
}
