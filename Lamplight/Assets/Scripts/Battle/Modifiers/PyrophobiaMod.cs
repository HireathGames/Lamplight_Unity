using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PyrophobiaMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        base.playerTurnStart(player);
        List<Enemy> enemies = player.manager.getEnemies();
        if (enemies != null)
        {
            int ran = Random.Range(0, enemies.Count);
            player.attackEntity(enemies[ran], 0, 20, 't');
        }
    }
}
