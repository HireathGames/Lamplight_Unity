using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTrail : Card
{
    public PaperTrail() : base("Paper Trail", "The targeted enemy gains 1 mark at the start of every turn.", 1, true, false, true, 't', "PaperTrail") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new PaperTrailMod(player.focus));
        player.playAnimation(3);
    }
}
