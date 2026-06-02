using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgment : Card
{
    public Judgment() : base("Judgment", "Double an enemies mark.", 1, true, false, true, 'w', "Judgment", "JudgmentAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.mark *= 2;
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(3);
    }
}
