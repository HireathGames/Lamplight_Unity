using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Determination : Card
{
    public Determination() : base("Determination", "Heal all damage taken this turn at the start of next turn.", 3, false, false, false, 'w', "Determination", "DeterminationAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new DeterminationMod());
        player.playAnimation(3);
    }
}
