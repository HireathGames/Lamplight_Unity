using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guilt : Card
{
    public Guilt() : base("Guilt", "Apply 1 weakness and 8 broken.", 1, true, false, false, 'm', "Guilt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.weakness += 1;
        player.focus.broken += 8;
        player.playAnimation(3);
    }
}
