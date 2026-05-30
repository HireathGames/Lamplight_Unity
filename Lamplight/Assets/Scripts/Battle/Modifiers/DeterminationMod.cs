using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminationMod : CombatModifier
{
    private int health;
    private bool done = false;
    public override void playerTookDamage(Player player, int damage)
    {
        if (!done)
        {
            health += damage;
        }
    }
    public override void playerTurnStart(Player player)
    {
        if (!done)
        {
            player.setHealth(player.getHealth() + health);
            player.healthBar.updateUI(player);
            done = true;
        }
    }
}
