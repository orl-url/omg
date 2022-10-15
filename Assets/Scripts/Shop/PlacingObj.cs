using Buildings;
using TotalMoney;
using UnityEngine;

public class PlacingObj : MonoBehaviour
{
    public Building wall;
    public ObjCost objCost;
    
    private Vector2 _startPos;

    public void SetStartingPos(Transform obj)
    {
        _startPos = obj.position;
    }

    public void SetMousePos(Transform obj)
    {
        if (objCost.cost > objCost.score.score) {return;}
        obj.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void PlaceObj(Transform obj)
    {
        if (objCost.cost <= objCost.score.score)
        {
            var newWall = Instantiate(wall, obj.position, Quaternion.identity);
            objCost.SpendGold();
            obj.position = _startPos;
        }
    }
}
