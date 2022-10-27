using System;
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
                case BuildingType.WoodenWall:
                {
                    goldStorage -= WoodenWall.cost;
                    break;
                }
                case BuildingType.ArcherTowerLvl1:
                {
                    goldStorage -= ArcherTowerLvl1.cost;
                    break;
                }
                case BuildingType.ArcherTowerLvl2:
                {
                    goldStorage -= ArcherTowerLvl2.cost;
                    break;
                }
                case BuildingType.StoneWall:
                {
                    goldStorage -= StoneWall.cost;
                    break;
                }
            }
        }
    }
}