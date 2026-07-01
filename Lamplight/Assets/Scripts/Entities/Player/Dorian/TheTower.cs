using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheTower : Card
{
    public TheTower() : base("XVI The Tower", "Deal 2-4X damage to an enemy X times.", 0, true, true, false, 'b', "The Tower") { }
    public override void play(int spentEnergy, Player player)
    {
        for (int i = 0; i < spentEnergy; i++)
        {
            player.attackEntity(player.focus, Random.Range(2, (spentEnergy * 4) + 1), 0, getType());
        }
        player.playAnimation(4);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Deal " + modifiedDamage(entity, 2) + "-" + modifiedDamage(entity, 4) + "X damage X times.");
    }
}
