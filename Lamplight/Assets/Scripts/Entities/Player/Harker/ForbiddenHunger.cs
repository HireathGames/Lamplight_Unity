using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenHunger: Card
{
    public ForbiddenHunger() : base("Forbidden Hunger", "Heal equal to an enemies current bleed.", 1, true, false, true, 'b', "Forbidden Hunger") { }
    public override void play(int spentEnergy, Player player)
    {
        player.setHealth(player.getHealth() + player.focus.bleed);
        if (player.getHealth() > player.getMaxHealth())
        {
            player.setHealth(player.getMaxHealth());
        }
        player.playAnimation(3);
    }
}
