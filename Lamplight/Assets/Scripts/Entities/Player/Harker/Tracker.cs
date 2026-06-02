using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : Card
{
    public Tracker() : base("Tracker", "Deal 3 damage to an enemy, it doesn't loose mark when taking this damage.", 0, true, false, false, 't', "Tracker") { }
    public override void play(int spentEnergy, Player player)
    {
        int oriMark;
        oriMark = player.focus.mark;
        player.attackEntity(player.focus, 3, 0, getType());
        player.focus.mark = oriMark;
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(1);
    }
}
