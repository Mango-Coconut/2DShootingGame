using UnityEngine;

public class HealPortion : Item
{
    [SerializeField] private int healAmount = 1;

    public override void Apply(Player player)
    {
        player.Heal(healAmount);
    }
}
