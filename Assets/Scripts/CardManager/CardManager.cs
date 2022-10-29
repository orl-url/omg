using System;
using System.Collections.Generic;
using TotalMoney;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour    
{
    public WavesManager wavesManager;
    public GameObject cardsCanvas;
    public TotalGold totalGold;
    public List <GameObject> atkCards, defCards, otherCards, specialCards, currentCardPrefs;

    private List<Progress.Item> _bufferForUsedCard;
    [SerializeField] private List <GameObject> cardOnScreen = new List<GameObject>();


    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCommonCards()
    {
        CreateCommonCard(atkCards, -700, 0);
        
        CreateCommonCard(defCards,0, 0);
        
        CreateCommonCard(otherCards, 700, 0);
        
        cardsCanvas.SetActive(true);
    }

    private GameObject  CreateCommonCard(List <GameObject> cards , float x, float y)
    {
        var currentCardPref = cards[Random.Range(0, cards.Count)];
        currentCardPrefs.Add(currentCardPref);

        var card = Instantiate(currentCardPref, currentCardPref.transform.position = new Vector2(x, y), Quaternion.identity);
        card.transform.SetParent(cardsCanvas.transform, false);
        cardOnScreen.Add(card);
        return card;
    }
    
    public void CreateSpecialCards()
    {
        CreateSpecialCard(specialCards, -700, 0);
        
        CreateSpecialCard(specialCards,0, 0);
        
        CreateSpecialCard(specialCards, 700, 0);
        
        cardsCanvas.SetActive(true);
    }
    
    private GameObject  CreateSpecialCard(List <GameObject> cards , float x, float y)
    {
        var currentCardPref = cards[Random.Range(0, cards.Count)];
        currentCardPrefs.Add(currentCardPref);

        var card = Instantiate(currentCardPref, currentCardPref.transform.position = new Vector2(x, y), Quaternion.identity);
        card.transform.SetParent(cardsCanvas.transform, false);
        cardOnScreen.Add(card);
        return card;
    }

    public void DeleteCardFromList(CardsTypes typeCard)
    {
        switch (typeCard)
        {
            case CardsTypes.AttackCard: 
                atkCards.Remove(currentCardPrefs[0]);
                break;
            case CardsTypes.DefendCard:
                defCards.Remove(currentCardPrefs[1]);
                break;
            case CardsTypes.OtherCard:
                otherCards.Remove(currentCardPrefs[2]);
            break;
            case CardsTypes.SpecialCard:
                foreach (var pref in currentCardPrefs)
                {
                    specialCards.Remove(pref);
                }
                break;
        }
    }

    public void DestroyScreenCardsAndPlayGame()
    {
        cardOnScreen.Clear();
        currentCardPrefs.Clear();
        // for (var i = 0; i <= cardOnScreen.Count - 1; i++)
        // {
        //     Destroy(cardOnScreen[i]);
        //     cardOnScreen.Remove(cardOnScreen[i]);
        // }
        cardsCanvas.SetActive(false);
        
        wavesManager.PlayGame();
    }
}

public enum CardsTypes
{
    AttackCard,
    DefendCard,
    OtherCard,
    SpecialCard,
}
