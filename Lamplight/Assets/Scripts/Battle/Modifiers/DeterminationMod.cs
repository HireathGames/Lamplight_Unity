using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminationMod : CombatModifier
{
    private int health;
    public override void playerTookDamage(Player player, int damage)
    {
        if (!isDone())
        {
            health += damage;
        }
    }
    public override void playerTurnStart(Player player)
    {
        if (!isDone())
        {
            player.setHealth(player.getHealth() + health);
            makeDone();
        }
    }
}
