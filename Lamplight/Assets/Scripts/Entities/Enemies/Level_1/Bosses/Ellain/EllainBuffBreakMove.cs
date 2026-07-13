using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EllainBuffBreakMove : EnemyMove
{
    public EllainBuffBreakMove() : base("Debuff", 2) { }
    public override void performMove(Enemy self, Player player)
    {
        player.broken += 3;
        List<Enemy> enemies = self.GetComponent<Ellain>().getSummons();
        foreach (Enemy e in enemies)
        {
            e.strength++;
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "3";
    }
}
