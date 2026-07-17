using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injustice : Card
{
    public Injustice() : base("Injustice", "If this card is still in you hand at the end of your turn, gain 2 mark.", 2, false, false, true, 't', "Injustice") { }
    public override void play(int spentEnergy, Player player)
    {

    }
    public override void retainedEffect(Player player)
    {
        player.mark += 2;
    }
}
