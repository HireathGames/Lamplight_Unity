using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearingAct: Card
{
    public DisapearingAct() : base("Disapearing Act", "Whenever you switch between Jekyll and Hyde, gain 10 armor.", 1, false, false, true, 'w', "Disapearing Act") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new DisapearingActMod());
        player.playAnimation(3);
    }
}
