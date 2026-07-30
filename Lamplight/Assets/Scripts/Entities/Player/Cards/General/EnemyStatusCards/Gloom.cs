using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gloom : Card
{
    public Gloom() : base("Gloom", "If this card is still in you hand at the end of your turn, for the rest of combat take 1 damage every time you play a card.", 1, false, false, false, 'n', "Gloom") { }
    public override void play(int spentEnergy, Player player)
    {

    }
    public override void retainedEffect(Player player)
    {
        player.addModifier(new GloomMod());
    }
}
