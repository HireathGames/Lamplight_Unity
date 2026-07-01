using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLovers : Card
{
    public TheLovers() : base("VI The Lovers", "Add a copy of the next card you play to your deck, it costs 0.", 1, false, false, true, 'm', "The Lovers") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new LoversMod());
        player.playAnimation(4);
    }
}
