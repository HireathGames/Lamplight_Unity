using UnityEngine;

public class FaustianMod : CombatModifier
{
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        if (card is Delirium)
        {
            player.manager.getDiscard().Insert(0, new Delirium());
        }
    }
}
