using UnityEngine;

public class LoversMod : CombatModifier
{
    private bool active;
    public override void playedCard(Player player, Card card)
    {
        if (!isDone() && active)
        {
            base.playedCard(player, card);
            Card copy = card.copyCard();
            copy.setOriginalCost(0);
            player.manager.getDeck().Add(copy);
            makeDone();
        }
        else
        {
            active = true;
        }
    }
}
