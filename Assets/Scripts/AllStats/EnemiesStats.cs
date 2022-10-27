using System.Collections.Generic;
using Enemies;
using UnityEngine;

public static class EnemiesStats
{
    public class AnyGoblin
    {
        public float health;

        public float damage;

        public float attackCooldown;

        public float coinsForDeath;

        public float speed;

        public static readonly List<Enemy> allEnemies = new List<Enemy>();

        private static readonly List<AnyGoblin> AllGoblinsTypes = new List<AnyGoblin>();

        public static readonly AnyGoblin LittleGoblin = new AnyGoblin()
        {
            health = 100f,
            damage = 20,
            attackCooldown = 1,
            coinsForDeath = 2,
            speed = 1f,
        };

        public static readonly AnyGoblin BossGoblin = new AnyGoblin()
        {
            health = 200f,
            damage = 40f,
            attackCooldown = 0.2f,
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
                        goblin.damage += value;
                        break;
                    }
                    case EnemyStats.AttackCooldown:
                    {
                        goblin.attackCooldown += value;
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
        
        public enum EnemyStats
        {
            Health,
            Damage,
            AttackCooldown,
            CoinsForDeath,
            Speed,
            
        }
    }
}
