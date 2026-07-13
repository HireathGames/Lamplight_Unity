using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psychoanalyse : Card
{
    public Psychoanalyse() : base("Psychoanalyse", "An enemy loses 5 sanity, it loses additional sanity equal to 2 times its broken.", 0, true, false, false, 'm', "Psychoanalyse") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 0, 5 + (player.focus.broken * 2.0f), getType());
        player.playAnimation(3);
    }
}
