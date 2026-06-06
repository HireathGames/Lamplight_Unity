using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : Card
{
    public Alive() : base("Alive!", "Gain 3 strength.", 1, false, false, true, 'w', "Alive") { }
    public override void play(int spentEnergy, Player player)
    {
        player.strength += 3;
        player.healthBar.updateUI(player);
        player.playAnimation(3);
    }
}
