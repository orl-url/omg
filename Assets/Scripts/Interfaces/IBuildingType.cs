namespace Interfaces
{
    public interface IBuildingType
    {
        BuildingType SetType();
        
        public enum BuildingType
        {
            Castle,
            WoodenWall,
            StoneWall,
            ArcherTowerLevel1,
            ArcherTowerLevel2,
        }
    }
}
