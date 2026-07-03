using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crooked : Card
{
    public Crooked() : base("Crooked", "If this card is still in you hand at the end of your turn, gain 3 broken than take damage equal to your broken.", 2, false, false, true, 'n', "Crooked") { }
    public override void play(int spentEnergy, Player player)
    {
        player.playAnimation(3);
    }
    public override void retainedEffect(Player player)
    {
        player.broken += 3;
        player.takeDamage(player.broken, 0, 't');
    }
}
