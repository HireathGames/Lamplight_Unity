using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EllainBuffBreakMove : EnemyMove
{
    public EllainBuffBreakMove() : base("Debuff", 1) { }
    public override void performMove(Enemy self, Player player)
    {
        player.broken += 3;
        player.healthBar.updateUI(player);
        List<Enemy> enemies = self.GetComponent<Ellain>().getSummons();
        foreach (Enemy e in enemies)
        {
            e.strength++;
        }
    }
}
