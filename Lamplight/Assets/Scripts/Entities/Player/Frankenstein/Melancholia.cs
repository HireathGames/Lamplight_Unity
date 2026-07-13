using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melancholia : Card
{
    public Melancholia() : base("Melancholia", "Every time an entity has a breakdown, they gain 2 weakness and you gain 20 block.", 1, false, false, true, 't', "Melancholia", "MelancholiaAlt") { }
    public override void play(int spentEnergy, Player player)
    {
        player.addModifier(new MelancholiaMod());
        player.playAnimation(3);
    }
}
