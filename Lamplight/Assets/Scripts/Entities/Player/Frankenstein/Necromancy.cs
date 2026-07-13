using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancy : Card
{
    public Necromancy() : base("Necromancy", "Gain 6 regeneration.", 1, false, false, true, 't', "Necromancy", "NecromancyAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.regeneration += 6;
        player.playAnimation(3);
    }
}
