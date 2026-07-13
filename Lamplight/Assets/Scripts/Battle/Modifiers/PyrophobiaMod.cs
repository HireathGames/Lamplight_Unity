using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PyrophobiaMod : CombatModifier
{
    private float sanityDamage = 10;
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        List<Enemy> enemies = player.manager.getEnemies();
        if (enemies != null)
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.takeDamage(0, sanityDamage, 't');
            }
        }
    }
    public override void enemyBreakdown(Player player, Enemy enemy)
    {
        sanityDamage += 10;
    }
}
