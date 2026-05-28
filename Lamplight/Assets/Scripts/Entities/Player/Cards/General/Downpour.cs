using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downpour : Card
{
    public Downpour() : base("Downpour", "Deal 5 damage to all enemies.", 1, false, false, false, 'm', "Downpour") { }
    public override void play(int spentEnergy, Player player)
    {
        foreach (Enemy e in player.manager.getEnemies())
        {
            player.attackEntity(e, 5, 0, getType());
        }
        player.playAnimation(3);
    }
}
