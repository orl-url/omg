using System;
using TotalMoney;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEngine;
using static BuildingsStats.AnyBuilding;

public class PlacingObj : MonoBehaviour
{
    public Building woodenWall;
    public Building archerTower;
    public Building stoneWall;
    public Canvas canvas;
    
    private string _currentColliderName;
    private bool _flagForUpgradeWall;
    // private BuildingsStats.AnyBuilding _currentBuildingType;

    int ShopMask = 1 << 6;
    private int maxValue = int.MaxValue;

    private Building _createdObject;
    private TotalGold _totalGold;

    public void Init(TotalGold totalGold)
    {
        _totalGold = totalGold;
    }
    

    private Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void BeginDrag()
    {
        var hitInfo = Physics2D.Raycast(GetMousePosition(), Vector2.zero);
        
        _currentColliderName = hitInfo.collider.name;
        Debug.Log(_currentColliderName);

        switch (_currentColliderName)
        {
            
            case "WoodenWall":
            {
                CreateBuilding(woodenWall, WoodenWall);
                break;
            }
            case "ArcherTower":
            {
                CreateBuilding(archerTower, ArcherTower);
               break;
            }
            case "StoneWall":
            {
                CreateBuilding(stoneWall, StoneWall);
               break;
            }
        }
    }

    private void CreateBuilding(Building buildingPref, BuildingsStats.AnyBuilding buildingStats)
    {
        if (_totalGold.goldStorage >= buildingStats.cost)
        {
            _createdObject = Instantiate(buildingPref, GetMousePosition(), quaternion.identity);
            _createdObject.Init(buildingStats);
            _createdObject.transform.SetParent(canvas.transform, true);
            allBuildings.Add(_createdObject);
        }
    }
    
    public void MovingCreatedObj()
    {
        if (_createdObject != null)
        {
            _createdObject.transform.position = GetMousePosition();
        }
    }

    
    // Добавить свич.
    public void EndDragPlaceBuilding()
    {
        if (_totalGold.goldStorage >= WoodenWall.cost)
        {
            SpendGold();
            _createdObject = null;
        }
    }

    public void EndDragBuildingUpgrade()
    {
        _createdObject.DropBuilding(_createdObject, GetMousePosition(), maxValue, ShopMask);
    }
        
    
    public void SpendGold()
    {
        switch (_currentColliderName)
        {
            case "WoodenWall":
            {
                _totalGold.goldStorage -= WoodenWall.cost;
                break;
            }
            case "ArcherTower":
            {
                _totalGold.goldStorage -= ArcherTower.cost;
                break;
            }
            case "StoneWall":
            {
                _totalGold.goldStorage -= StoneWall.cost;
                break;
            }
        }
    }
}
