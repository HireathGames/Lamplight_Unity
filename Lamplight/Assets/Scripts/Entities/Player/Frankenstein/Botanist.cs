using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botanist : Card
{
    public Botanist() : base("Botanist", "Deal 2 damage, this card deals 3 additional damage for each regeneration you have.", 0, true, false, false, 't', "Botanist") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 2 + (player.regeneration * 3), 0, getType());
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + (2 + (entity.regeneration * 3)) + "damage, this card deals 3 additional damage for each regeneration you have.");
    }
}
