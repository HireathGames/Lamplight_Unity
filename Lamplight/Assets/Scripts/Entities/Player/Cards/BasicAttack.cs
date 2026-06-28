using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Card
{
    //overrides the constructor but still calls original constructor.
    public BasicAttack(string n, char t, string a) : base(n, "Deal 5 damage to an enemy.", 1, true, false, false, t, a) { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 5, 0, getType());
        player.playAnimation(1);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 5) +" damage to an enemy.");
    }
}
