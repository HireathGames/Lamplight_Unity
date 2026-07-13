using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinfulShadow : Card
{
    public SinfulShadow() : base("Sinful Shadow", "Gain equal armor to the amount of broken an enemy has, then activate their broken.", 3, true, false, false, 'm', "Sinful Shadow", "Sinful ShadowAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addArmor(player.focus.broken);
        player.focus.takeDamage(player.focus.broken, 0, 'm');
        player.focus.broken = 0;
        player.playAnimation(3);
    }
}
