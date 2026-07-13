using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgment : Card
{
    public Judgment() : base("Just Desserts", "Double an enemies mark.", 1, true, false, true, 'w', "Judgment", "JudgmentAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.focus.mark *= 2;
        player.playAnimation(3);
    }
}
