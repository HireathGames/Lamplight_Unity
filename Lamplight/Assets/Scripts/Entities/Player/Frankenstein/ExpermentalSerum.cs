using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpermentalSerum : Card
{
    public ExpermentalSerum() : base("Expermental Serum", "Gain strength equal to your regeneration.", 1, false, false, true, 't', "Expermental Serum") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += player.regeneration;
        player.playAnimation(3);
    }
}
