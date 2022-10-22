using UnityEngine;
using static EnemiesStats;

public class OtherBonuses : MonoBehaviour
{
    private CardManager _cardManager;
    public void Init(CardManager cardManager)
    {
        _cardManager = cardManager;
    }

    public void IncreaseCoinsValue()
    {
        AnyGoblin.DoForAllElements("coinsForDeath", 5);
        DeletingCards();
    }
    
    private void DeletingCards()
    {
        _cardManager.DeleteCardFromList("other");
        _cardManager.DestroyCards();
    }

}
