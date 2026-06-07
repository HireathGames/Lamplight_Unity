using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : Card
{
    public Reflection() : base("Reflection", "Copy the effect of a random other card in your hand.", 1, true, false, false, 'n', "Reflection") { }
    public override void play(int spentEnergy, Player player)
    {
        if (player.manager.getHand().Count > 1)
        {
            int ran = Random.Range(0, player.manager.getHand().Count);
            player.manager.getHand()[ran].play(spentEnergy, player);
        }
    }
}
