using System.Collections.Generic;
using Buildings;
using Buildings.Castle;
using Enemies;
using UnityEngine;
using Weapons;

public class CardManager : MonoBehaviour
{
    public WavesManager wavesManager;
    public GameObject cardsCanvas;
    public List <GameObject> atkCards;
    public List <GameObject> defCards;
    public List <GameObject> otherCards;

    public Arrow arrow;
    public ArrowsSpawner arrowsSpawner;
    public Building wall;
    public Enemy enemy;

    private GameObject _currentAtkCard;
    private GameObject _currentDefCard;
    private GameObject _currentOtherCard;

    private GameObject _leftButton;
    private GameObject _middleButton;
    private GameObject _rightButton;

        // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCards()
    {
        Time.timeScale = 0;

        _currentAtkCard = atkCards[Random.Range(0, atkCards.Count)];
        _leftButton = Instantiate(_currentAtkCard, _currentAtkCard.transform.position = new Vector2(-700, 0), Quaternion.identity);
        _leftButton.transform.SetParent(cardsCanvas.transform, false);
        var attackBonuses = _leftButton.gameObject.GetComponent<AttackBonuses>();
        attackBonuses.Init(this);
        
        
        _currentDefCard = defCards[Random.Range(0, defCards.Count)];
        _middleButton = Instantiate(_currentDefCard, _currentDefCard.transform.position = new Vector2(0, 0), Quaternion.identity);
        _middleButton.transform.SetParent(cardsCanvas.transform, false);
        var defendBonuses = _middleButton.gameObject.GetComponent<DefendBonuses>();
        defendBonuses.Init(this);
        
        
        _currentOtherCard = otherCards[Random.Range(0, otherCards.Count)];
         _rightButton = Instantiate(_currentOtherCard, _currentOtherCard.transform.position = new Vector2(700, 0), Quaternion.identity);
         _rightButton.transform.SetParent(cardsCanvas.transform, false);
        var otherBonuses = _rightButton.gameObject.GetComponent<OtherBonuses>();
        otherBonuses.Init(this);
        
        cardsCanvas.SetActive(true);
    }


    public void CardFromList(string typeCard)
    {
        switch (typeCard)
        {
            case "attack":
                atkCards.Remove(_currentAtkCard);
                break;
            case "defend":
                defCards.Remove(_currentDefCard);
                break;
            case "other":
                otherCards.Remove(_currentOtherCard);
                break;
        }
        atkCards.Remove(_currentAtkCard);
    }

    public void DeleteCards()
    {
        Destroy(_leftButton);
        Destroy(_middleButton);
        // Destroy();
        PlayGame();
    }

    private void PlayGame()
    {
        cardsCanvas.SetActive(false);
        Time.timeScale = 1;
        wavesManager.NextWave();
    }
}
