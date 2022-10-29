
using Unity.VisualScripting;

public class Castle : Building
{
    private void Awake()
    {
        Init(BuildingsStats.AnyBuilding.Castle);
        SetWeaponParameters();
    }

    
    private void SetWeaponParameters()
    {
        var weapon = GetComponentInChildren<ArrowWeapon>();
        weapon.Init(BuildingsStats.AnyBuilding.Castle);
    }
}
