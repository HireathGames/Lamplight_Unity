using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : Card
{
    public Alive() : base("Alive!", "Gain 2 strength.", 2, false, false, true, 'w', "Alive") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 2;
        player.healthBar.updateUI(player);
        player.playAnimation(3);
    }
}
