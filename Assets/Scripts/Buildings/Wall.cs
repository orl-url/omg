using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Building
{
    private void Awake()
    {
        Init(BuildingsStats.AnyBuilding.Wall);
    }
}
