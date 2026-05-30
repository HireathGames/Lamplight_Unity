using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hollow : Card
{
    public Hollow() : base("Hollow", "Remove all negative status effects.", 0, false, false, true, 't', "Hollow", "HollowAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.mark = 0;
        player.bleed = 0;
        player.broken = 0;
        player.weakness = 0;
        player.healthBar.updateUI(player);
        player.playAnimation(3);
    }
}
