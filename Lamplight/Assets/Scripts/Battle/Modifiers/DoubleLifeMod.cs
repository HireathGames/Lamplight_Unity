using UnityEngine;

public class DoubleLifeMod : CombatModifier
{
    public override void jekyllHydeTransformation(Player player)
    {
        base.jekyllHydeTransformation(player);
        player.strength++;
    }
}
