using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManicMayham : Card
{
    public ManicMayham() : base("Manic Mayham", "Deal 2-4X damage X times.", 0, true, true, false, 'b', "Manic Mayham") { }
    public override void play(int spentEnergy, Player player)
    {
        for (int i = 0; i < spentEnergy; i++)
        {
            player.attackEntity(player.focus, Random.Range(2, (spentEnergy * 4) + 1), 0, getType());
        }
        player.playAnimation(1);
    }
}
