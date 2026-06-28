using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedingHeart : Card
{
    public BleedingHeart() : base("Bleeding Heart", "Deal 5 damage to an enemy, then apply 2 bleed.", 1, true, false, false, 'w', "Bleeding Heart") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 5, 0, getType());
        player.focus.bleed += 2;
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 5) + " damage to an enemy, then apply 2 bleed.");
    }
}
