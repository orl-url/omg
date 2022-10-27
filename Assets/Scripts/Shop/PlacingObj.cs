using System;
using TotalMoney;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEngine;
using static BuildingsStats.AnyBuilding;

public class PlacingObj : MonoBehaviour
{
    private string _currentColliderName;
    private bool _flagForUpgradeWall;

    public Canvas thisCanvas;

 

    private Building _createdObject;
    public TotalGold totalGold;

    // public void Init(TotalGold totalGold)
    // {
    //     _totalGold = totalGold;
    // }
    
    // public static Vector3 GetMousePosition()
    // {
    //     var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     mousePos.z = 0;
    //     return mousePos;
    // }

    // public void CreateBuilding(Building buildingPref, BuildingsStats.AnyBuilding buildingStats)
    // {
    //     if (_totalGold.goldStorage >= buildingStats.cost)
    //     {
    //         _createdObject = Instantiate(buildingPref, GetMousePosition(), quaternion.identity);
    //         _createdObject.Init(buildingStats);
    //         _createdObject.transform.SetParent(canvas.transform, true);
    //         allBuildings.Add(_createdObject);
    //     }
    // }
    
    // public void MovingCreatedObj()
    // {
    //     if (_createdObject != null)
    //     {
    //         _createdObject.transform.position = GetMousePosition();
    //     }
    // }

    
    // Добавить свич.
    // public void EndDragPlaceBuilding()
    // {
    //     if (_totalGold.goldStorage >= WoodenWall.cost)
    //     {
    //         SpendGold();
    //         _createdObject = null;
    //     }
    // }

    // public void EndDragBuildingUpgrade()
    // {
    //     _createdObject.DropBuilding(_createdObject, GetMousePosition(), maxValue, ShopMask);
    // }
        
    
    
}
