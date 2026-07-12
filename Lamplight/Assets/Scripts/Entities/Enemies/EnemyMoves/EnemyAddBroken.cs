using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddBroken : EnemyMove
{
    private int broken;
    public EnemyAddBroken(int broke) : base("Debuff")
    {
        broken = broke;
    }
    public EnemyAddBroken(int broke, int anim) : base("Debuff", anim)
    {
        broken = broke;
    }
    public override void performMove(Enemy self, Player player)
    {
        player.broken += broken;
        player.healthBar.updateUI(player);
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return broken.ToString();
    }
}
