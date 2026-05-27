using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tragedy : Card
{
    public Tragedy() : base("Tragedy", "Give an enemy 3 weakness.", 1, true, false, false, 'm', "Tragedy") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.weakness += 3;
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(3);
    }
}
