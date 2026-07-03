using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddStatusCard : EnemyMove
{
    private Card status;
    private int copies;
    public EnemyAddStatusCard(Card card, int copyNumber) : base("StatusCard", 3)
    {
        status = card;
        copies = copyNumber;
    }
    public EnemyAddStatusCard(Card card, int copyNumber, int anim) : base("StatusCard", anim)
    {
        status = card;
        copies = copyNumber;
    }
    public override void performMove(Enemy self, Player player)
    {
        for (int i = 0; i < copies; i++)
        {
            player.manager.getDiscard().Add(status);
        }
        player.healthBar.updateUI(player);
    }
}
