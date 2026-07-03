using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manifest : Card
{
    public Manifest() : base("Manifest", "Deal 3 damage and gain 3 armor, then draw a card.", 1, true, false, false, 'b', "Manifest") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 3, 0, getType());
        player.addArmor(3);
        player.manager.draw();
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 3) + " damage and gain " + modifiedArmor(entity, 3) + " armor, then draw a card.");
    }
}
