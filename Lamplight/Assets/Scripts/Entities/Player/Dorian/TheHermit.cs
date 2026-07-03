using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHermit : Card
{
    public TheHermit() : base("IX The Hermit", "Play the top card of your deck 3 times.", 2, false, false, false, 't', "TheHermit") { }
    public override void play(int spentEnergy, Player player)
    {
        if (player.manager.getDeck().Count > 0 && player.manager.getDeck()[0] != null)
        {
            player.focus = player.manager.getEnemies()[0];
            for (int i = 0; i < 3; i++)
            {
                player.manager.getDeck()[0].play(2, player);
            }
        }
        else if (player.manager.getDiscard().Count > 0 && player.manager.getDiscard()[0] != null)
        {
            player.focus = player.manager.getEnemies()[0];
            for (int i = 0; i < 3; i++)
            {
                player.manager.getDiscard()[0].play(2, player);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (player.manager.getDeck().Count > 0 && player.manager.getDeck()[0] != null)
            {
                player.playCardModUpdate(player.manager.getDeck()[0]);
            }
            else if (player.manager.getDiscard().Count > 0 && player.manager.getDiscard()[0] != null)
            {
                player.playCardModUpdate(player.manager.getDiscard()[0]);
            }
        }
        player.playAnimation(4);
    }
}
