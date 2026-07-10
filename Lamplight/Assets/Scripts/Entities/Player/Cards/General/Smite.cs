using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smite : Card
{
    public Smite() : base("Smite", "Gain 1 strength this turn then deal 6 damage.", 1, true, false, false, 'b', "Smite") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 1;
        player.addModifier(new TempStrengthMod(1));
        player.attackEntity(player.focus, 6, 0, getType());
        player.healthBar.updateUI(player);
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Gain 1 strength this turn then deal " + modifiedDamage(entity, 6) + " damage.");
    }
}
