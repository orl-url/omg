using System.Collections.Generic;
using Enemies;
using UnityEngine;

public static class EnemiesStats
{
    public class AnyGoblin
    {
        public float health;

        public float meleeDamage, rangeDamage;

        public float meleeAttackCooldown, rangeAttackCooldown;

        public float coinsForDeath;

        public float speed, arrowSpeed;

        public static readonly List<Enemy> AllEnemies = new List<Enemy>();

        private static readonly List<AnyGoblin> AllGoblinsTypes = new List<AnyGoblin>();

        public static readonly AnyGoblin LittleGoblin = new AnyGoblin()
        {
            health = 100f,
            meleeDamage = 20,
            meleeAttackCooldown = 1,
            coinsForDeath = 2,
            speed = 0.5f,
        };

        public static AnyGoblin GoblinDefender = new AnyGoblin()
        {
            health = 100f,
            meleeDamage = 25f,
            meleeAttackCooldown = 0.5f,
            
            rangeDamage = 50f,
            rangeAttackCooldown = 0.2f,
            
            coinsForDeath = 1,
            speed = 1f,
        };
        
        public static readonly AnyGoblin ThrowerGoblin = new AnyGoblin()
        {
            health = 300f,
            meleeDamage = 10f,
            meleeAttackCooldown = 0.5f,
            
            rangeDamage = 10f,
            rangeAttackCooldown = 0.2f,
            
            coinsForDeath = 1,
            speed = 2.5f,
        };
        
        public static readonly AnyGoblin ArcherGoblin = new AnyGoblin()
        {
            health = 200f,
            // meleeDamage = 10f,
            // meleeAttackCooldown = 0.5f,
            
            rangeDamage = 25f,
            rangeAttackCooldown = 0.5f,
            
            // arrowSpeed = 3f,
            
            coinsForDeath = 1,
            speed = 2.5f,
        };
        
        
        public static readonly AnyGoblin BossGoblin = new AnyGoblin()
        {
            health = 200f,
            meleeDamage = 40f,
            meleeAttackCooldown = 0.2f,
            coinsForDeath = 1,
            speed = 2f,
        };

        private static List<AnyGoblin> AddAllGoblinsToList()
        {
            AllGoblinsTypes.Add(LittleGoblin);
            AllGoblinsTypes.Add(BossGoblin);
            return AllGoblinsTypes;
        }

        public static void DoForAllElements(EnemyStats statName, float value)
        {
            var allGoblins = AddAllGoblinsToList();
            
            foreach (var goblin in allGoblins)
            {
                switch (statName)
                {
                    case EnemyStats.Health:
                        goblin.health += value;
                        break;
                    case EnemyStats.Damage:
                    {
                        goblin.meleeDamage += value;
                        break;
                    }
                    case EnemyStats.AttackCooldown:
                    {
                        goblin.meleeAttackCooldown += value;
                        break;
                    }
                    case EnemyStats.CoinsForDeath:
                    {
                        goblin.coinsForDeath += value;
                        break;
                    }
                    case EnemyStats.Speed:
                    {
                        goblin.speed *= value;
                        break;
                    }
                }
            }
        }
    }
}
