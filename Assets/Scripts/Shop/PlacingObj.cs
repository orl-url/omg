using System;
using TotalMoney;
using Unity.Mathematics;
using UnityEngine;
using static BuildingsStats;

public class PlacingObj : MonoBehaviour
{
    public Building wall;
    

    private Building _objTemp;
    private TotalGold _totalGold;
    private string _currentColliderName;


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
        
        
        if ( _totalGold.goldStorage >= AnyBuilding.WoodenWall.cost)
        {
                _objTemp = Instantiate(wall, GetMousePosition(), quaternion.identity);
                AnyBuilding.allBuildings.Add(_objTemp);
        }
    }

    public void MovingCreatedObj()
    {
        if (_objTemp != null)
        {
            _objTemp.transform.position = GetMousePosition();
        }
    }

    public void DragEnd()
    {
        if (_totalGold.goldStorage >= AnyBuilding.WoodenWall.cost)
        {
            SpendGold();
            _objTemp = null;
        }
    }

    public void SpendGold()
    {
        _totalGold.goldStorage -= AnyBuilding.WoodenWall.cost;
    }
}
