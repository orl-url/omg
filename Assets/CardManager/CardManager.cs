using System;
using Buildings.Castle;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Weapons;

public class CardManager : MonoBehaviour
{
    public WavesManager wavesManager;
    public GameObject cardsCanvas;
    public GameObject card;
    public Arrow arrow;
    public ArrowsSpawner arrowsSpawner;
    
    
    private CardsMethods _cardsMethods;


    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCards()
    {
        Time.timeScale = 0; 
        
        var leftButton = Instantiate(card, card.transform.position = new Vector2(-700, 0), Quaternion.identity);
        leftButton.transform.SetParent(cardsCanvas.transform, false);
        _cardsMethods = leftButton.gameObject.GetComponent<CardsMethods>();
        _cardsMethods.Init(this);
            
        var midButton = Instantiate(card, card.transform.position = new Vector2(0, 0), Quaternion.identity);
        midButton.transform.SetParent(cardsCanvas.transform, false);
        
        var rightButton = Instantiate(card, card.transform.position = new Vector2(700, 0), Quaternion.identity);
        rightButton.transform.SetParent(cardsCanvas.transform, false);
        
        cardsCanvas.SetActive(true);
    }
    
    
    public void ContinueGame()
    {
        _cardsMethods.AddArrowDamage();
        _cardsMethods.ChangeCastleAttackSpeed();
        
        cardsCanvas.SetActive(false);
        Time.timeScale = 1;
        wavesManager.NextWave();
    }
    
}
