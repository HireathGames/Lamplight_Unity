using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake : Card
{
    public Stake() : base("Stake", "Deal 25 damage to an enemy.", 3, true, false, false, 't', "Stake", "StakeAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 25, 0, getType());
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 25) + " damage to an enemy.");
    }
}
