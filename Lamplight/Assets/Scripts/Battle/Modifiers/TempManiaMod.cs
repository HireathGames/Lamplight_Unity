using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManiaMod : CombatModifier
{
    private int mania;

    public TempManiaMod(int inMania)
    {
        mania = inMania;
    }
    public override void playerTurnStart(Player player)
    {
        if (!isDone())
        {
            player.mania -= mania;
            player.healthBar.updateUI(player);
            makeDone();
        }

    }
}
