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
    [SerializeField]
    private Vector3 _woodenWallPos;
    private BuildingsStats.AnyBuilding _currentBuildingType;    

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
                if (_totalGold.goldStorage >= WoodenWall.cost)
                {
                    _createdObject = Instantiate(woodenWall, GetMousePosition(), quaternion.identity);
                    _createdObject.GetComponent<Building>().Init(WoodenWall);
                    // _createdObject.transform.SetParent(canvas.transform, true);
                    allBuildings.Add(_createdObject);
                }
                break;
            }
            case "ArcherTower":
            {
                if (_totalGold.goldStorage >= ArcherTower.cost)
                {
                    _createdObject = Instantiate(archerTower, GetMousePosition(), quaternion.identity);
                    _createdObject.GetComponent<Building>().Init(ArcherTower);
                    _createdObject.GetComponentInChildren<ArrowsSpawner>().Init(ArcherTower);
                    
                    allBuildings.Add(_createdObject);
                }
                break;
            }
            case "StoneWall":
            {
                if (_totalGold.goldStorage >= StoneWall.cost)
                {
                    _createdObject = Instantiate(stoneWall, GetMousePosition(), quaternion.identity);
                    _createdObject.GetComponent<Building>().Init(StoneWall);
                    // _createdObject.transform.SetParent(canvas.transform, true);
                    _createdObject.AddComponent<PlacingObj>();

                    allBuildings.Add(_createdObject);
                }
                break;
            }
        }
    }

    public void MovingCreatedObj()
    {
        // Debug.Log(_woodenWallPos);
        if (_createdObject != null)
        {
            _createdObject.transform.position = GetMousePosition();
            
        }
    }

    
    // Добавить свич.
    public void DragEnd()
    {
        
        if (_totalGold.goldStorage >= WoodenWall.cost)
        {
            SpendGold();
            _createdObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("WoodenWall"))
        {
            Debug.Log(other.name);

            _flagForUpgradeWall = true;
            // Debug.Log(_flagForUpgradeWall);
            // Debug.Log(other.transform.position);/
            Debug.Log(other.transform.position);
            _woodenWallPos = other.transform.position;
            _woodenWallPos = other.transform.position;
            // Debug.Log("correctPos" +_woodenWallPos);
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        _flagForUpgradeWall = false;
        // Debug.Log(_flagForUpgradeWall);
        // Debug.Log("after exit" + _woodenWallPos);
    }

    public void EndDragWallUpgrade()
    {
        // if (_flagForUpgradeWall == true)
        // {
            Debug.Log("Placed");
            // Debug.Log(_woodenWallPos);
            _createdObject.transform.position  = _woodenWallPos;
            // }
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
