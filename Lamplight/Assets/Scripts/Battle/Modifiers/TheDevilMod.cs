using UnityEngine;

public class TheDevilMod : CombatModifier
{
    public override void playedCard(Player player, Card card)
    {
        base.playedCard(player, card);
        if (card is Delirium)
        {
            player.strength++;
            player.healthBar.updateUI(player);
        }
    }
}
