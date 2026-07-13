using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtuousPresence : Card
{
    public VirtuousPresence() : base("Virtuous Presence", "Gain 7 armor and apply 7 broken to an enemy, shuffle a Sin into you deck.", 0, true, false, false, 'm', "Virtue") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addArmor(7);
        player.focus.broken += 7;
        int ran = Random.Range(0, player.manager.getDeck().Count);
        player.manager.getDeck().Insert(ran, new SinDebuff());
        player.playAnimation(2);
    }
    public override void updateDiscription(Entity entity)
    {
        setDiscription("Gain " + modifiedArmor(entity, 7) + " armor and apply 7 broken to an enemy, shuffle a Sin into you deck.");
    }
}
