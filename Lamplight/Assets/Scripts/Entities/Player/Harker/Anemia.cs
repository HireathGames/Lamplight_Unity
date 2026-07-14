using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemia : Card
{
    public Anemia() : base("Anemia", "Apply 5 bleed to an enemy.", 1, true, false, false, 'm', "Anemia") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.bleed += 5;
        player.playAnimation(1);
    }
}
