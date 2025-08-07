using UnityEngine;

public class Coin : Item
{
    [SerializeField] private int score = 1;

    public override void Apply(Player player)
    {
        GameManager.Instance.AddScore(score);
    }
}
