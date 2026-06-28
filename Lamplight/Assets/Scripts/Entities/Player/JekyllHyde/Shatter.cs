using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : Card
{
    public Shatter() : base("Shatter", "Deal 8 damage to an enemy, then apply 5 broken.", 2, true, false, false, 'm', "Shatter") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 8, 0, getType());
        player.focus.broken += 5;
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 8) + " damage to an enemy, then apply 5 broken.");
    }
}
