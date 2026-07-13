using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTome : Card
{
    public PowerTome() : base("Tome Of Power", "Gain 3 strength and add 1 Delirium to your deck.", 1, false, false, true, 'b', "PowerTome") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 3;
        int ran = Random.Range(0, player.manager.getDeck().Count);
        player.manager.getDeck().Insert(ran, new Delirium());
        player.playAnimation(4);
    }
}
