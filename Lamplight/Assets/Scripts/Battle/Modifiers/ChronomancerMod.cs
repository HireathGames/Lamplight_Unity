using UnityEngine;

public class ChronomancerMod : CombatModifier
{
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        player.manager.draw();
    }
}
