using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListObjs : MonoBehaviour
{
   public List<Transform> _allObjs = new List<Transform>();
   private Scene _gameScene;
   private void Start()
   {
       _gameScene = SceneManager.GetActiveScene();

       _gameScene.GetRootGameObjects();
      foreach (Transform obj in gameObject.transform)
      {
         _allObjs.Add(obj);
      }

   }
}
