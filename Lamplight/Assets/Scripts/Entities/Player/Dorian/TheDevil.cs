using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDevil : Card
{
    public TheDevil() : base("XV The Devil", "Every time you play a Delirium, gain 1 strength", 2, false, false, true, 'b', "The Devil") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new TheDevilMod());
        player.playAnimation(4);
    }
}
