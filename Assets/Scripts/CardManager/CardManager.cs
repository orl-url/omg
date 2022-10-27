using System;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEditor;
using UnityEngine;
using Weapons;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour    
{
    public WavesManager wavesManager;
    public GameObject cardsCanvas;
    public List <GameObject> atkCards, defCards, otherCards, currentCardPrefs;

    private List<Progress.Item> _bufferForUsedCard;
    [SerializeField] private List <GameObject> cardOnScreen = new List<GameObject>();


    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCards()
    {
        CreateCard(atkCards, -700, 0);
        
        CreateCard(defCards,0, 0);
        
        CreateCard(otherCards, 700, 0);
        
        cardsCanvas.SetActive(true);
        
    }

    private GameObject  CreateCard(List <GameObject> cards , float x, float y)
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
        }
    }

    public void DestroyScreenCardsAndPlayGame()
    {
        for (var i = 0; i <= cardOnScreen.Count - 1; i++)
        {
            Destroy(cardOnScreen[i]);
        }
        
        wavesManager.PlayGame();
    }
}

public enum CardsTypes
{
    AttackCard,
    DefendCard,
    OtherCard,
}
