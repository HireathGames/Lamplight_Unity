using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddBleed : EnemyMove
{
    private int bleed;
    public EnemyAddBleed(int blood) : base("Debuff")
    {
        bleed = blood;
    }
    public EnemyAddBleed(int blood, int anim) : base("Debuff", anim)
    {
        bleed = blood;
    }
    public override void performMove(Enemy self, Player player)
    {
        player.bleed += bleed;
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return bleed.ToString();
    }
}
