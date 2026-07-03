using UnityEngine;

public class MasochistMod : CombatModifier
{
    public override void playerTookDamage(Player player, int damage)
    {
        base.playerTookDamage(player, damage);
        player.strength++;
    }
}
