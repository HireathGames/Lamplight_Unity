using UnityEngine;

public class DisapearingActMod : CombatModifier
{
    public override void jekyllHydeTransformation(Player player)
    {
        base.jekyllHydeTransformation(player);
        player.addArmor(10);
    }
}
