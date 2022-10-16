using System;
using System.Collections;
using System.Collections.Generic;
using Buildings;
using UnityEngine;
using UnityEngine.UI;

public class PlacingObj : MonoBehaviour
{
    public Building wall;
    public GameObject canvas;
    
    public void SetMousePos(Transform obj)
    {
       obj.position =  (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void PlaceWall(GameObject obj)
    {
        print("some");
        var newWall =Instantiate(wall, obj.transform.position, Quaternion.identity);
        // newWall.transform.SetParent(canvas.transform, true);
    }
}
