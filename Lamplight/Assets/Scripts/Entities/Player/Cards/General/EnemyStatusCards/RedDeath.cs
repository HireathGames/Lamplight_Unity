using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDeath : Card
{
    public RedDeath() : base("Red Death", "If this card is still in you hand at the end of your turn, gain 3 bleed.", 1, false, false, false, 'w', "Red Death") { }
    public override void play(int spentEnergy, Player player)
    {

    }
    public override void retainedEffect(Player player)
    {
        player.bleed += 3;
    }
}
