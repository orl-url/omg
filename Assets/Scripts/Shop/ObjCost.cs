using TotalMoney;
using UnityEngine;

public class ObjCost : MonoBehaviour
{
    public int cost;
    public Score score;

    public void SpendGold()
    {
        score.score -= cost;
    }
}
