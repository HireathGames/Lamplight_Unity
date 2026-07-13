using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : Card
{
    public Performance() : base("Performance", "Gain 8 armor and 1 temporary mania.", 2, false, false, false, 'b', "Performance") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addArmor(8);
        player.mania++;
        player.addModifier(new TempManiaMod(1));
        player.playAnimation(3);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Gain " + modifiedArmor(entity, 8) + " armor and 1 temporary mania.");
    }
}
