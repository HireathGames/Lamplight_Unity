using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrement : Card
{
    public Sacrement() : base("Sacrement", "Deal 7 damage to an enemy, then apply 4 bleed.", 2, true, false, false, 'w', "Sacrement") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 7, 0, getType());
        player.focus.bleed += 4;
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 7) + " damage to an enemy, then apply 4 bleed.");
    }
}
