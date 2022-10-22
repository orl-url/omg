using TotalMoney;
using UnityEngine;

public class ObjCost : MonoBehaviour
{
    [Range(1, 50)]
    public int cost;
    public Score score;

    public void SpendGold()
    {
        score.score -= cost;
    }

    public void Init()
    {
        print("some");
    }
}
