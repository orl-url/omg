using System;

namespace Enemies
{
    public class LittleGoblin : Enemy
    {
        private void Awake()
        {
            Init(EnemiesStats.AnyGoblin.LittleGoblin);
        }
    }
}
