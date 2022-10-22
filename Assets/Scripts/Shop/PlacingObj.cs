using TotalMoney;
using Unity.Mathematics;
using UnityEngine;
using static BuildingsStats;

public class PlacingObj : MonoBehaviour
{
    public Building wall;

    private Building _wallTemp;
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

    public void OnMouseDrag()
    {
        if ( _totalGold.goldStorage >= AnyBuilding.WoodenWall.cost)
        {
            _wallTemp = Instantiate(wall, GetMousePosition(), quaternion.identity);
            AnyBuilding.allBuildings.Add(_wallTemp);
        }
    }

    public void SpendGold()
    {
        _totalGold.goldStorage -= AnyBuilding.WoodenWall.cost;
    }
    public void MovingCreatedWall()
    {
        _wallTemp.transform.position = GetMousePosition();
    }

    public void DragEnd()
    {
        if (_totalGold.goldStorage >= BuildingsStats.AnyBuilding.WoodenWall.cost)
        {
            SpendGold();
            _wallTemp = null;
        }
    }
}
