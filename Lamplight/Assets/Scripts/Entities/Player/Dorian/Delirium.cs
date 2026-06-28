using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delirium : Card
{
    public Delirium() : base("Delirium", "If this card is still in you hand at the end of your turn, lose 10 sanity.", 1, false, false, false, 'b', "Delirium") { }
    public override void play(int spentEnergy, Player player)
    {
        player.playAnimation(-3);
    }
    public override void retainedEffect(Player player)
    {
        player.takeDamage(0, 10f, 'b');
    }
}
