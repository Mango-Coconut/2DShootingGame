using UnityEngine;

public class PowerItem : Item
{
    public override void Apply(Player player)
    {
        player.PowerUp();
    }
}
