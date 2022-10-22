using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingsStats
{
    public class AnyBuilding
    {
        public float hp;
        public float touchDamage;
        public float touchDamageCooldown;
        public float attackRadius;

        public float arrowDamage;
        public float arrowSpeed;
        public float attackCooldown;
        
        public float cost;

        public static List<Building> allBuildings = new List<Building>();

        private static readonly List<AnyBuilding> AllWallTypes = new List<AnyBuilding>();

        public static readonly AnyBuilding WoodenWall = new AnyBuilding()
        {
            hp = 1,
            touchDamage = 0.5f,
            touchDamageCooldown = 1f,
            
            cost = 5f,
        };

        public static readonly AnyBuilding Castle = new AnyBuilding()
        {
            // Castle.
            hp = 1,
            touchDamage = 0f,
            touchDamageCooldown = 0.5f,
            attackRadius = 15f,
            attackCooldown = 0.5f,

            // Weapon.
            arrowSpeed = 10f,
            arrowDamage = 0.5f,
        };

        private static List<AnyBuilding> AddAllWallTypesToList()
        {
            AllWallTypes.Add(WoodenWall);
            return AllWallTypes;
        }
    }
}
