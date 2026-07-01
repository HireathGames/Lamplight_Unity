using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallucination : Card
{
    public Hallucination() : base("Hallucination", "Draw two cards???", 0, false, false, false, 'n', "Hallucination") { }
    public override void play(int spentEnergy, Player player)
    {
        player.manager.draw();
        player.manager.draw();
        if (!player.manager.getHand()[player.manager.getHand().Count - 1].getIsX())
        {
            player.manager.getHand()[player.manager.getHand().Count - 1].setCost(Random.Range(0, 4));
            player.manager.getHand()[player.manager.getHand().Count - 1].randomize();
        }
        if (!player.manager.getHand()[player.manager.getHand().Count - 2].getIsX())
        {
            player.manager.getHand()[player.manager.getHand().Count - 2].setCost(Random.Range(0, 4));
            player.manager.getHand()[player.manager.getHand().Count - 2].randomize();
        }
        player.playAnimation(3);
    }
}
