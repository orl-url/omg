using System;
using TotalMoney;
using Unity.Mathematics;
using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;

public class PlacingObj : MonoBehaviour
{
    public Building wall;
    public GameObject canvas;
    public GameObject woodenWall;

    private Transform _mousePos;
    private Building _wallTemp;

    public Vector3 GetMousePosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public void OnMouseDrag()
    {
        {
            
        }
        
        _wallTemp = Instantiate(wall, GetMousePosition(), quaternion.identity);
    }

    public void MovingCreatedWall()
    {
        _wallTemp.transform.position = GetMousePosition();

    }
}
