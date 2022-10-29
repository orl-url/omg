using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using static BuildingsStats.AnyBuilding;

namespace TotalMoney
{
    public class TotalGold : MonoBehaviour
    {
        public Text scoreDisplay;
        public Canvas canvas;
        
        internal float goldStorage;

        private void FixedUpdate()
        {
            scoreDisplay.text = "Gold: " + goldStorage.ToString();
        }
        
        public void SpendGold(BuildingType buildingType)
        {
            switch (buildingType)
            {
                case BuildingType.Wall:
                {
                    goldStorage -= BuildingsStats.AnyBuilding.Wall.cost;
                    break;
                }
                case BuildingType.ArcherTower:
                {
                    goldStorage -= BuildingsStats.AnyBuilding.ArcherTower.cost;
                    break;
                }
                // case BuildingType.ArcherTowerLevel2:
                // {
                //     goldStorage -= ArcherTowerLvl2.cost;
                //     break;
                // }
                // case BuildingType.StoneWall:
                // {
                //     goldStorage -= StoneWall.cost;
                //     break;
                // }
            }
        }

        public void AddGold(float goldValue)
        {
            goldStorage += goldValue;
        }
    }
}