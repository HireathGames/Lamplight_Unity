using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadScience : Card
{
    public MadScience() : base("Mad Science", "Gain 2 regeneration and a randomized negative effect.", 1, false, false, false, 'b', "Mad Science") { }
    public override void play(int spentEnergy, Player player)
    {
        player.regeneration += 2;
        int ran = Random.Range(0, 5);
        if (ran == 0)
        {
            player.broken += 2;
        }
        else if (ran == 1)
        {
            player.weakness += 1;
        }
        else if (ran == 2)
        {
            player.mark += 1;
        }
        if (ran == 3)
        {
            player.bleed += 2;
        }
        else
        {
            player.takeDamage(0, 10, 't');
        }
        player.playAnimation(3);
    }
}
