using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comedy : Card
{
    public Comedy() : base("Comedy", "Gain 3 strength this turn.", 0, false, false, false, 'b', "Comedy") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 3;
        player.addModifier(new TempStrengthMod(3));
        player.playAnimation(3);
    }
}
