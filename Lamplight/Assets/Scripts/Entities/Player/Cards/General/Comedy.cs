using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comedy : Card
{
    public Comedy() : base("Comedy", "Gain 5 strength this turn.", 0, false, false, false, 'b', "Comedy") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 5;
        player.addModifier(new TempStrengthMod(5));
        player.healthBar.updateUI(player);
        player.playAnimation(3);
    }
}
