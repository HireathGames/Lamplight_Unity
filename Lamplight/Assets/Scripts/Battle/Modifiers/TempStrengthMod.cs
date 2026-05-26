using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStrengthMod : CombatModifier
{
    private int strength;
    private bool done = false;
    public TempStrengthMod(int inStrength)
    {
        strength = inStrength;
    }
    public override void playerTurnStart(Player player)
    {
        if (!done)
        {
            player.strength -= strength;
            player.healthBar.updateUI(player);
            done = true;
        }
    }
}
