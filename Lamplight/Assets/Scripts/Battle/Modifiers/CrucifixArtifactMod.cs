using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrucifixArtifactMod : CombatModifier
{
    public override void playerTurnStart(Player player)
    {
        int ran = Random.Range(0, player.manager.getEnemies().Count);
        player.manager.getEnemies()[ran].mark++;
        player.manager.getEnemies()[ran].healthBar.updateUI(player.manager.getEnemies()[ran]);
    }
}
