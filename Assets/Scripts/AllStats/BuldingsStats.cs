using System.Collections.Generic;

public static class BuildingsStats
{
    public class AnyBuilding
    {
        public float hp;
        public float arrowDamage, arrowSpeed, attackRadius, attackCooldown;
        public float cost;
        public int arrowsValue;
        

        public static readonly List<Building> allBuildings = new List<Building>();
        private static readonly List<AnyBuilding> AllWallTypes = new List<AnyBuilding>();

        
        public static readonly AnyBuilding Castle = new AnyBuilding()
        {
            // Castle.
            hp = 100,

            // Detection Area.
            attackRadius = 15f,

            // Weapon.
            attackCooldown = 0.5f,
            arrowSpeed = 15f,
            arrowDamage = 50f,
            arrowsValue = 1,
        };

        public static readonly AnyBuilding Wall = new AnyBuilding()
        {
            // Wall.
            hp = 1,
  
            
            cost = 5f,
        };
        
        public static readonly AnyBuilding ArcherTower = new AnyBuilding()
        {
            // ArcherTower.
            hp = 40,
            
            // Detection Area.
            attackRadius = 5f,
            
            // Weapon.
            attackCooldown = 0.5f,
            // arrowSpeed = 10f,
            // arrowDamage = 0.5f,
            
            cost = 10f,
        };


        private static List<AnyBuilding> AddAllBuildingsTypesToList()
        {
            AllWallTypes.Add(Wall);
            return AllWallTypes;
        }

        public static void DoForAllBuildings(string fieldName, float value)
        {
            var allBui = AddAllBuildingsTypesToList();
            foreach (var building in allBui)
            {
                switch (fieldName)
                {
                    case "AttackRadius":
                    {
                        building.attackCooldown *= 2;
                        break;
                    }
                }
            }
        }
    }
}
