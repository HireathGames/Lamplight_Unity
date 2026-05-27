using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddWeakness : EnemyMove
{
    private int weakness;
    public EnemyAddWeakness(int weak) : base("Debuff")
    {
        weakness = weak;
    }
    public EnemyAddWeakness(int weak, int anim) : base("Debuff", anim)
    {
        weakness = weak;
    }
    public override void performMove(Enemy self, Player player)
    {
        player.weakness += weakness;
        player.healthBar.updateUI(player);
    }
}
