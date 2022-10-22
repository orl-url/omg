using System;
using UnityEngine;
using static BuildingsStats; 
using static BonusesStats;

public class AttackBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    private ArrowsSpawner _arrowsSpawner;

    // ArrowWave bonus.
    private readonly float _arrowWaveCooldown = arrowWaveCooldown ;
    // public bool _flagCreateArrowWave = flagCreateArrowWave;
    private float _currentArrowWaveTime = 1f;


    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    private void Update()
    {
        _currentArrowWaveTime -= Time.deltaTime;
        
        if (flagCreateArrowWave == true && _currentArrowWaveTime <= 0)
        {
            this.CreateArrowWave();
            _currentArrowWaveTime = _arrowWaveCooldown;
        }
    }

    public void IncreaseArrowDamage()
    {
        AnyBuilding.Castle.arrowDamage += 0.5f;
        DeletingCards();
    }
    
    public void IncreaseCastleAttackSpeed()
    {
        AnyBuilding.Castle.attackCooldown -= 0.15f;
        DeletingCards();
    }

    private void AddArrowWave()
    {
        flagCreateArrowWave = true;
        CreateArrowWave();
        DeletingCards();
    }

    private void CreateArrowWave()
    {
        var i = 0;
        while (i < 12)
        {
            print(flagCreateArrowWave);
            var position = transform.position;
            var rotation = Quaternion.Euler(0, 0, 30 * i);
            // Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg - 30 * i);

            // var rotation = Quaternion.Euler(0, 0,  90);
            Instantiate(_cardManager.arrowsSpawner.arrow, _cardManager.arrowsSpawner.arrowShotPoint.position, rotation);
            i++;
        }
    }

    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList("attack");
        _cardManager.MoveCardsToListOfUsed();
    }
}
