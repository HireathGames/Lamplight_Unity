using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCoin : Card
{
    public LuckyCoin() : base("Lucky Coin", "Deal 1-4 damage then draw a card.", 0, true, false, false, 'b', "Lucky Coin") { }
    public override void play(int spentEnergy, Player player)
    {
        player.attackEntity(player.focus, Random.Range(1, 5), 0);
        player.manager.draw();
        player.playAnimation(1);
    }
}
