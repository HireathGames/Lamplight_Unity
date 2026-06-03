using UnityEngine;

public class PatchworkMod : CombatModifier
{
    public override void playerTookDamage(Player player, int damage)
    {
        base.playerTookDamage(player, damage);
        player.regeneration++;
    }
}
