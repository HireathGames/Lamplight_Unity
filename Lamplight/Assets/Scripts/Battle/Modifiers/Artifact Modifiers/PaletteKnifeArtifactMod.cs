using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PaletteKnifeArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        if (!isDone())
        {
            player.mania++;
            makeDone();
        }
    }
}
