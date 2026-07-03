using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chronomancer : Card
{
    public Chronomancer() : base("Chronomancer", "Every time you play a card, draw 1 card.", 2, false, false, true, 'b', "Chronomancer", "ChronomancerAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new ChronomancerMod());
        player.playAnimation(4);
    }
}
