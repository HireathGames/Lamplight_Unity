using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMagician : Card
{
    public TheMagician() : base("I The Magician", "Deal 6 damage for each card played this turn.", 1, true, false, false, 'b', "Magician") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, (6 * player.getPlayedCardsNumber()), 0, 'b');
        player.playAnimation(4);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 6) + " damage for each card played this turn.");
    }
}
