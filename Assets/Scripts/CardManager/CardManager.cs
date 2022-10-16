using Buildings.Castle;
using UnityEngine;
using Weapons;

public class CardManager : MonoBehaviour
{
    public WavesManager wavesManager;
    public GameObject cardsCanvas;
    public GameObject atkCard;
    public GameObject defendCard;
    public GameObject otherCard;
    public Arrow arrow;
    public ArrowsSpawner arrowsSpawner;
    public GameObject wall;
    
    private GameObject _button;
    private AttackBonuses _attackBonuses;
    private DefendBonuses _defendBonuses;
    private OtherBonuses _otherBonuses;
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateCards()
    {
        Time.timeScale = 0;

        _button = Instantiate(atkCard, atkCard.transform.position = new Vector2(-700, 0), Quaternion.identity);
        _button.transform.SetParent(cardsCanvas.transform, false);
        _attackBonuses = _button.gameObject.GetComponent<AttackBonuses>();
        _attackBonuses.Init(this);
        
        _button = Instantiate(defendCard, defendCard.transform.position = new Vector2(0, 0), Quaternion.identity);
        _button.transform.SetParent(cardsCanvas.transform, false);
        _defendBonuses = _button.gameObject.GetComponent<DefendBonuses>();
        _defendBonuses.Init(this);
        
        _button = Instantiate(otherCard, otherCard.transform.position = new Vector2(700, 0), Quaternion.identity);
        _button.transform.SetParent(cardsCanvas.transform, false);
        _otherBonuses = _button.gameObject.GetComponent<OtherBonuses>();
        _otherBonuses.Init(this);
        
        cardsCanvas.SetActive(true);
    }
     public void PlayGame()
    {
        cardsCanvas.SetActive(false);
        Time.timeScale = 1;
        wavesManager.NextWave();
    }
}
