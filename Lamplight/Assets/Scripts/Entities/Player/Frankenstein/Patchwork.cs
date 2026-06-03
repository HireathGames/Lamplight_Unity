using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patchwork : Card
{
    public Patchwork() : base("Patchwork", "Every time you take unblocked damage gain 1 regeneration.", 1, false, false, true, 't', "Patchwork") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new PatchworkMod());
        player.playAnimation(3);
    }
}
