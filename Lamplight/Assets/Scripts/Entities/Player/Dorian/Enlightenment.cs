using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlightenment : Card
{
    public Enlightenment() : base("Enlightenment", "Gain 1 mania and add 2 Delirium to your deck.", 1, false, false, true, 'b', "Enlightenment") { }
    public override void play(int spentEnergy, Player player)
    {
        player.mania++;
        int ran = Random.Range(0, player.manager.getDeck().Count);
        player.manager.getDeck().Insert(ran, new Delirium());
        ran = Random.Range(0, player.manager.getDeck().Count);
        player.manager.getDeck().Insert(ran, new Delirium());
        player.healthBar.updateUI(player);
        player.playAnimation(-3);
    }
}
