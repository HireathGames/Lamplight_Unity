using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malice : Card
{
    public Malice() : base("Malice", "Gain 2 strength this turn then double vice.", 0, false, false, false, 'w', "Malice") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 2;
        player.addModifier(new TempStrengthMod(2));
        if (player is JekyllAndHyde jh)
        {
            jh.changeVice(jh.getVice());
        }
        player.playAnimation(3);
    }
}
