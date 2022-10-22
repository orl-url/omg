using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingsStats
{
    public class AnyBuilding
    {
        // Castle.
        public float hp;
        public float touchDamage;
        public float touchDamageCooldown;
        public float attackRadius;

        // Weapon
        public float arrowDamage;
        public float arrowSpeed;
        public float attackCooldown;
        
        
        private static readonly List<AnyBuilding> AllWallTypes = new List<AnyBuilding>();

        private static List<AnyBuilding> AddAllWallTypesToList()
        {
            AllWallTypes.Add(woodenWall);
            return AllWallTypes;
        }

        public static AnyBuilding woodenWall = new AnyBuilding()
        {
            hp = 1,
            touchDamage = 0.5f,
            touchDamageCooldown = 1f,
            
        };
        
        public static AnyBuilding caslle = new AnyBuilding()
        {
            // Castle.
            hp = 0f,
            touchDamage = 0f,
            touchDamageCooldown = 0.5f,
            attackRadius = 5f,
            attackCooldown = 0.5f,

            // Weapon.
            arrowSpeed = 10f,
            arrowDamage = 0.5f,
        };


    }
}
