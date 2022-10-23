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
    public List <GameObject> atkCards;
    public List <GameObject> defCards;
    public List <GameObject> otherCards;

    public List <GameObject> currentCardPrefs;

    private List<Progress.Item> _bufferForUsedCard;
    // internal ArrowsSpawner arrowsSpawner;
    [SerializeField] private List <GameObject> cardOnScreen = new List<GameObject>();
    [SerializeField] private List<GameObject> usedCards;


    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCards()
    {
        Time.timeScale = 0;
        
        var card = CreateCard(atkCards, -700, 0);
        card.gameObject.GetComponent<AttackBonuses>().Init(this);
        
        card = CreateCard(defCards,0, 0);
        card.gameObject.GetComponent<DefendBonuses>().Init(this);
        
        card = CreateCard(otherCards, 700, 0);
        card.gameObject.GetComponent<OtherBonuses>().Init(this);
        
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

    public void DeleteCardFromList(string typeCard)
    {
        switch (typeCard)
        {
            case "attack":
                atkCards.Remove(currentCardPrefs[0]);
                break;
            case "defend":
                defCards.Remove(currentCardPrefs[1]);
                break;
            case "other":
                otherCards.Remove(currentCardPrefs[2]);
            break;
        }
    }

    public void DestroyCards()
    {
        for (var i = 0; i <= cardOnScreen.Count - 1; i++)
        {
            Destroy(cardOnScreen[i]);
        }
        
        PlayGame();
    }

    private void PlayGame()
    {
        // cardsCanvas.SetActive(false);
        Time.timeScale = 1;
        wavesManager.NextWave();
    }

    private void MoveComponentFromCard()
    {
        
    }
}
