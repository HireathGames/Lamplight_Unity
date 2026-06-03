using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntingGlare : Card
{
    public HauntingGlare() : base("Haunting Glare", "An enemy gains 2 weakness and loses 15 sanity.", 1, true, false, false, 't', "Haunting Glare") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, 0, 15, getType());
        player.focus.weakness += 2;
        player.playAnimation(3);
    }
}
