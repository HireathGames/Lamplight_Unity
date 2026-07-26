using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grief : Card
{
    public Grief() : base("Grief", "If this card is still in you hand at the end of your turn, gain 2 weakness.", 1, false, false, false, 'm', "Grief") { }
    public override void play(int spentEnergy, Player player)
    {

    }
    public override void retainedEffect(Player player)
    {
        player.weakness += 2;
    }
}
