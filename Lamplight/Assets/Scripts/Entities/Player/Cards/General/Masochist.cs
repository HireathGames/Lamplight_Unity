using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masochist : Card
{
    public Masochist() : base("Masochist", "Every time you take unblocked damage gain 1 strength.", 2, false, false, true, 'b', "Masochist") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new MasochistMod());
        player.playAnimation(3);
    }
}
