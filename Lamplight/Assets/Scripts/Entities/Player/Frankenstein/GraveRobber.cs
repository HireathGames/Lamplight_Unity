using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveRobber : Card
{
    public GraveRobber() : base("Grave Robber", "Deal 12 damage to an enemy. If that enemy dies, gain 3 regeneration.", 2, true, false, false, 't', "Grave Robber") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 12, 0, getType());
        if (player.focus.getHealth() <= 0)
        {
            player.regeneration += 3;
            if (player.healthBar != null)
            {
                player.healthBar.updateUI(player);
            }
        }
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 12) + " damage to an enemy. If that enemy dies, gain 3 regeneration.");
    }
}
