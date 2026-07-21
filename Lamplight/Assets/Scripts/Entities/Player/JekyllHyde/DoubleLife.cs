using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLife : Card
{
    public DoubleLife() : base("Double Life", "Whenever you switch between Jekyll and Hyde, gain 1 strength.", 1, false, false, true, 'b', "DoubleLife", "DoubleLifeAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new DoubleLifeMod());
        player.playAnimation(3);
    }
}
