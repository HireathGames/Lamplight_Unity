using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Card
{
    public Hunter() : base("Hunter", "Give an enemy 2 mark.", 1, true, false, false, 'w', "Hunter") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.mark += 2;
        player.playAnimation(3);
    }
}
