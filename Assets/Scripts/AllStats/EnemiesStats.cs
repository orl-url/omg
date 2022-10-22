using System.Collections.Generic;

public static class EnemiesStats
{
    public class AnyGoblin
    {
        public float health;

        public float damage;

        public float attackCooldown;

        public float coinsForDeath;

        public float speed;

        private static readonly List<AnyGoblin> AllGoblinsTypes = new List<AnyGoblin>();

        public static readonly AnyGoblin LittleGoblin = new AnyGoblin()
        {
            health = 0.5f,
            damage = 1,
            attackCooldown = 1,
            coinsForDeath = 1,
            speed = 1f,
        };

        public static readonly AnyGoblin BossGoblin = new AnyGoblin()
        {
            health = 0.5f,
            damage = 0.001f,
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

        public static void DoForAllElements( string fieldName, float value)
        {
            var allGoblins = AddAllGoblinsToList();
            
            foreach (var goblin in allGoblins)
            {
                switch (fieldName)
                {
                    case "health":
                        goblin.health += value;
                        break;
                    case "damage":
                    {
                        goblin.damage += value;
                        break;
                    }
                    case "attackCooldown":
                    {
                        goblin.attackCooldown += value;
                        break;
                    }
                    case "coinsForDeath":
                    {
                        goblin.coinsForDeath += value;
                        break;
                    }
                    case "speed":
                    {
                        goblin.speed += value;
                        break;
                    }
                }
            }
        }
    }
}
