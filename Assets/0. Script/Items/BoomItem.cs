using UnityEngine;

public class BoomItem : Item
{
    [SerializeField] private int boomAmount = 1;

    public override void Apply(Player player)
    {
        PlayerBoom boom = player.GetComponent<PlayerBoom>();
        if (boom != null)
        {
            boom.AddBoom(boomAmount);
        }
    }
}
