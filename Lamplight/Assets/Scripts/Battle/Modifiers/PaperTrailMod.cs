using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTrailMod : CombatModifier
{
    private Enemy enemy;
    public PaperTrailMod(Enemy target)
    {
        enemy = target;
    }
    public override void playerTurnStart(Player player)
    {
        if (enemy != null)
        {
            enemy.mark++;
        }
        else
        {
            makeDone();
        }
    }
}
