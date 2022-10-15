using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CardManager : MonoBehaviour
{
    public WavesManager wavesManager;
    public CardsMethods cardsMethods;
    public GameObject cardsCanvas;
    public GameObject leftCard;
    public GameObject midCard;
    public GameObject rightCard;


    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCards()
    {
        Time.timeScale = 0; 
        
        var leftButton = Instantiate(leftCard, leftCard.transform.position = new Vector2(-700, 0), Quaternion.identity);
        leftButton.transform.SetParent(cardsCanvas.transform, false);

        var midButton = Instantiate(midCard, midCard.transform.position = new Vector2(0, 0), Quaternion.identity);
        midButton.transform.SetParent(cardsCanvas.transform, false);
        
        var rightButton = Instantiate(rightCard, rightCard.transform.position = new Vector2(700, 0), Quaternion.identity);
        rightButton.transform.SetParent(cardsCanvas.transform, false);
        
        cardsCanvas.SetActive(true);
    }
    
    
    public void OnClickPlayGame()
    {
        cardsMethods.AddArrowDamage();
        cardsMethods.ChangeCastleAttackSpeed();
        
        cardsCanvas.SetActive(false);
        Time.timeScale = 1;
        wavesManager.NextWave();
    }
    
}
