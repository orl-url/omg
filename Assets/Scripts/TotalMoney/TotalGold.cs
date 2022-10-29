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
        
        public void SpendGold(IBuildingType.BuildingType buildingType)
        {
            switch (buildingType)
            {
                case IBuildingType.BuildingType.WoodenWall:
                {
                    goldStorage -= WoodenWall.cost;
                    break;
                }
                case IBuildingType.BuildingType.ArcherTowerLevel1:
                {
                    goldStorage -= ArcherTowerLvl1.cost;
                    break;
                }
                case IBuildingType.BuildingType.ArcherTowerLevel2:
                {
                    goldStorage -= ArcherTowerLvl2.cost;
                    break;
                }
                case IBuildingType.BuildingType.StoneWall:
                {
                    goldStorage -= StoneWall.cost;
                    break;
                }
            }
        }

        public void AddGold(float goldValue)
        {
            goldStorage += goldValue;
        }
    }
}