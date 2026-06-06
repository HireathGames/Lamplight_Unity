using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : Card
{
    private int damage = 5;
    public Murder() : base("Murder, Murder!", "Deal 5 damage, increase this cards damage by you current strength.", 2, true, false, false, 't', "Murder", "MurderAlt") 
    {
    }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, damage, 0, getType());
        damage += player.strength;
        setDiscription("Deal " + damage +" damage, increase this cards damage by you current strength.");
        player.focus.healthBar.updateUI(player.focus);
        player.playAnimation(1);
    }
}
