using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrify : Card
{
    public Electrify() : base("Electrify", "Deal 3X damage to all enemies and reduce their sanity by 15X.", 0, false, true, false, 't', "Electrify") { }
    public override void play(int spentEnergy, Player player)
    {
        foreach(Enemy e in player.manager.getEnemies())
        {
            player.attackEntity(e, (3 * spentEnergy), (15 * spentEnergy), getType());
        }
        player.playAnimation(3);
    }
}
