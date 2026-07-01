using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyrophobia : Card
{
    public Pyrophobia() : base("Pyrophobia", "At the start of each turn, random enemy loses 20 sanity.", 1, false, false, true, 't', "Pyrophobia", "PyrophobiaAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new PyrophobiaMod());
        player.playAnimation(3);
    }
}
