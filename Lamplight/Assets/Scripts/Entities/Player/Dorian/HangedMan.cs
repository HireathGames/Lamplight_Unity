using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangedMan : Card
{
    public HangedMan() : base("XII The Hanged Man", "At the end of the next X turns, gain 3X armor.", 0, false, true, false, 'w', "HangedMan") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new HangedManMod(spentEnergy, spentEnergy * 3));
        player.playAnimation(4);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("At the end of the next X turns gain " + modifiedArmor(entity, 3) + "X armor.");
    }
}
