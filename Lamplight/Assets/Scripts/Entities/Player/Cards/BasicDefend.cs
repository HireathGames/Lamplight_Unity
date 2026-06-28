using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicDefend : Card
{
    //overrides the constructor but still calls original constructor.
    public BasicDefend(string n, char t, string a) : base(n, "Gain 5 armor.", 1, false, false, false, t, a) { }
    public override void play(int spentEnergy, Player player)
    {
        player.addArmor(5);
        player.playAnimation(2);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Gain " + modifiedArmor(entity, 5) + " armor.");
    }
}
