using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecurringNightmare : Card
{
    public RecurringNightmare() : base("Recurring Nightmare", "An enemy loses 10 sanity, it loses an additional 25 for each times it has broken down.", 1, true, false, false, 't', "Recurring Nightmare") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 0, 10 + (player.focus.getBreakdowns() * 15), getType());
        player.playAnimation(3);
    }
}
