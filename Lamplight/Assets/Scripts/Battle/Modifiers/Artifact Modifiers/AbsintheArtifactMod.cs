using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsintheArtifactMod : CombatModifier
{
    private bool givenMania;
    public override void playerTurnStart(Player player)
    {
        if (!givenMania)
        {
            player.mania++;
            givenMania = true;
        }
        Card status = new Delirium();
        status.setBanished(true);
        player.manager.getDiscard().Insert(0, status);
    }
}
