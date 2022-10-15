using System;
using Buildings.Castle;
using UnityEngine;
using UnityEngine.UIElements;
using Weapons;

public class CardManager : MonoBehaviour
{
    public WavesManager wavesManager;
    private CardsMethods cardsMethods;
    public GameObject cardsCanvas;
    public CardsMethods card;
    public Arrow arrow;
    public ArrowsSpawner arrowsSpawner;

    // ReSharper disable Unity.PerformanceAnalysis

    public void Init(CardsMethods cardsMethods)
    {
        this.cardsMethods = cardsMethods;
    }
    
    private void Start()
    {
        card.Init(this);
        cardsMethods.Init(this);
    }

    public void CreateCards()
    {
        Time.timeScale = 0;

        var leftButton = Instantiate(card, card.transform.position = new Vector2(-700, 0), Quaternion.identity);
        leftButton.transform.SetParent(cardsCanvas.transform, false);

        var midButton = Instantiate(card, card.transform.position = new Vector2(0, 0), Quaternion.identity);
        midButton.transform.SetParent(cardsCanvas.transform, false);
        
        var rightButton = Instantiate(card, card.transform.position = new Vector2(700, 0), Quaternion.identity);
        rightButton.transform.SetParent(cardsCanvas.transform, false);
        
        cardsCanvas.SetActive(true);
    }
    
    
    public void OnClickPlayGame()
    {
        // cardsMethods.AddArrowDamage();
        // cardsMethods.ChangeCastleAttackSpeed();
        
        cardsCanvas.SetActive(false);
        Time.timeScale = 1;
        wavesManager.NextWave();
    }
    
}
