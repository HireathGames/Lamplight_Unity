using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinceCharming : Card
{
    public PrinceCharming() : base("Prince Charming", "Regain 20 sanity for each copy of Delirum in play, if you are at full sanity gain 1 temporary mania instead.", 1, false, false, true, 'b', "PrinceCharming", "PrinceCharmingAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        int times = 0;
        foreach (Card card in player.manager.getDeck())
        {
            if (card is Delirium)
            {
                times++;
            }
        }
        foreach (Card card in player.manager.getDiscard())
        {
            if (card is Delirium)
            {
                times++;
            }
        }
        foreach (Card card in player.manager.getHand())
        {
            if (card is Delirium)
            {
                times++;
            }
        }
        for (int i = 0; i < times; i++)
        {
            if (player.getSanity() < 100f)
            {
                player.setSanity(player.getSanity() + 20f);
            }
            else
            {
                player.mania++;
                player.addModifier(new TempManiaMod(1));
                player.healthBar.updateUI(player);
            }
        }
        player.healthBar.updateUI(player);
        player.playAnimation(3);
    }
}
