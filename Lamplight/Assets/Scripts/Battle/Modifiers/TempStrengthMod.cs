using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStrengthMod : CombatModifier
{
    private int strength;
    public TempStrengthMod(int inStrength)
    {
        strength = inStrength;
    }
    public override void playerTurnStart(Player player)
    {
        if (!isDone())
        {
            player.strength -= strength;
            makeDone();
        }
    }
}
