using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faustian : Card
{
    public Faustian() : base("Faustian Bargain", "Gain 4 mania and add 3 Delirium to your discard. Every time you play a Delirium, add a Delirium to your discard.", 0, false, false, true, 'b', "Faustian", "FaustianAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.mania += 4;
        for (int i = 0; i < 3; i++)
        {
            player.manager.getDiscard().Insert(0, new Delirium());
        }
        player.addModifier(new FaustianMod());
        player.playAnimation(4);
    }
}
