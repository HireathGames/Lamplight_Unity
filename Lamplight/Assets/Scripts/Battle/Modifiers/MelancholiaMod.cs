using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MelancholiaMod : CombatModifier
{
    public override void enemyBreakdown(Player player, Enemy enemy)
    {
        player.addArmor(20);
        enemy.weakness += 2;
    }
}
