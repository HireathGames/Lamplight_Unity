using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StarArtifactMod : CombatModifier
{
    private Player player;
    public override void playerTurnStart(Player player)
    {
        this.player = player;
        base.playerTurnStart(player);
        player.regeneration += 3;
        player.healthBar.updateUI(player);
        makeDone();
    }
}
