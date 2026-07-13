using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abjure : Card
{
    public Abjure() : base("Abjure", "Gain 7 armor and give an enemy 1 mark.", 1, true, false, false, 't', "Abjure") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.mark += 1;
        player.addArmor(7);
        player.playAnimation(3);
    }
}
