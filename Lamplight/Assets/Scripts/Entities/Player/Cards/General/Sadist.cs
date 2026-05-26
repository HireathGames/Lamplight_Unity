using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sadist : Card
{
    public Sadist() : base("Sadist", "Every time you attack an enemy they gain 1 bleed.", 2, false, false, true, 'w', "Sadist") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new SadistMod());
        player.playAnimation(3);
    }
}
