using Interfaces;
using TotalMoney;
using Unity.Mathematics;
using UnityEngine;
using static BuildingsStats.AnyBuilding;

public class ShopButton : MonoBehaviour
{
    public Building building;
    readonly int _shopMask = 1 << 6;
    private readonly int _maxValue = int.MaxValue;

    private TotalGold _buttonTotalGold;
    
    // private BuildingType _buildingOnButtonType;
    private Building _createdObject;

    private void Start()
    {
        _buttonTotalGold = GetComponentInParent<PlacingObj>().totalGold;
    }

    private Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void BeginDragTakeBuildingTypeAndCreate()
    {
        var buildingOnButtonType = building.type;
        switch (buildingOnButtonType)
        {
            case BuildingType.Wall:
            {
                CreateBuilding(building, BuildingsStats.AnyBuilding.Wall);
                break;
            }
            case BuildingType.ArcherTower:
            {
                CreateBuilding(building, BuildingsStats.AnyBuilding.ArcherTower);
                break;
            }
            // case BuildingType.ArcherTowerLevel2:
            // {
            //     CreateBuilding(building, ArcherTowerLvl2);
            //     break;
            // }
            // case BuildingType.StoneWall:
            // {
            //     CreateBuilding(building, StoneWall);
            //     break;
            // }
        }
    }
    
    private void CreateBuilding(Building buildingPref, BuildingsStats.AnyBuilding buildingStats)
    {
        if (_buttonTotalGold.goldStorage >= buildingStats.cost)
        {
            _createdObject = Instantiate(buildingPref, GetMousePosition(), quaternion.identity);
            // _createdObject.Init(buildingStats);
            _createdObject.transform.SetParent(GetComponentInParent<Canvas>().transform, true);
            allBuildings.Add(_createdObject);
        }
    }
    
    public void DragMovingCreatedObj()
    {
        if (_createdObject != null)
        {
            _createdObject.transform.position = GetMousePosition();
            
            _createdObject.transform.up = GetMousePosition();

        }
    }
    
    public void EndDragPlaceBuilding()
    {
        if (_buttonTotalGold.goldStorage >= BuildingsStats.AnyBuilding.Wall.cost)
        {
            SendGoldValue(_createdObject.type);
            _createdObject = null;
        }
    }
    
    public void EndDragBuildingUpgrade()
    {
        // _createdObject.DropBuildingOnScreen(GetMousePosition(), _maxValue, _shopMask);
    }

    private void SendGoldValue(BuildingType buildingType)
    {
        _buttonTotalGold.SpendGold(buildingType);
    }
}
