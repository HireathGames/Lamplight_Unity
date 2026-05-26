using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadistMod : CombatModifier
{
    public override void playerAttacked(Player player)
    {
        player.focus.bleed += 1;
        player.focus.healthBar.updateUI(player.focus);
    }
}
