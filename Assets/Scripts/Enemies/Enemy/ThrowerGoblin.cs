using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class ThrowerGoblin : Enemy   
    {
        private void Awake()
        {
            Init(EnemiesStats.AnyGoblin.ThrowerGoblin);
        }
    }
}
