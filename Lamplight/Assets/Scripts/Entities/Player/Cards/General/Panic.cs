using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panic : Card
{
    public Panic() : base("Panic", "Targeted enemy loses 25 sanity.", 1, true, false, false, 't', "Panic") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 0, 25, getType());
        player.playAnimation(3);
    }
}
