using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TillDeath : Card
{
    public TillDeath() : base("Till Death", "Give an enemy 4 mark, then give yourself 2 mark.", 1, true, false, false, 'm', "Till Death") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.mark += 4;
        player.mark += 2;
        player.healthBar.updateUI(player);
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(3);
    }
}
