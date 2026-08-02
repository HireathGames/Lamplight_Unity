using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class CopperArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        player.addArmor(20);
        makeDone();
    }
}
