using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangedManMod : CombatModifier
{
    private int turns;
    private int amount;

    public HangedManMod(int inTurns, int inAmount)
    {
        turns = inTurns;
        amount = inAmount;
    }
    public override void playerTurnEnd(Player player)
    {
        if (!isDone())
        {
            if (turns <= 0)
            {
                makeDone();
            }
            else
            {
                player.addArmor(amount);
                turns--;
            }
        }
    }
}
