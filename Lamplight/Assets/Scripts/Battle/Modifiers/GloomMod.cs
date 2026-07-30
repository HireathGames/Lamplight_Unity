using UnityEngine;

public class GloomMod : CombatModifier
{
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        player.takeDamage(1, 0, 'n');
    }
}
