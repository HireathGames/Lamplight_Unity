using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class FinalActArtifacttMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        player.regeneration += 6;
        player.manager.getDeck().Insert(Random.Range(0, player.manager.getDeck().Count), new Delirium());
        player.manager.getDeck().Insert(Random.Range(0, player.manager.getDeck().Count), new Delirium());
        makeDone();
    }
}
