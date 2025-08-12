using UnityEngine;

public class CoinItem : Item
{
    [SerializeField] private int score = 1;

    public override void Apply(Player player)
    {
        GameManager.Instance.AddScore(score);
    }
}
