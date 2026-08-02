using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EllainBuffDebuffCardMove : EnemyMove
{
    public EllainBuffDebuffCardMove() : base("StatusCard", 2) { }
    public override void performMove(Enemy self, Player player)
    {
        player.manager.getDiscard().Add(new Grief());
        List<Enemy> enemies = self.GetComponent<Ellain>().getSummons();
        foreach (Enemy e in enemies)
        {
            e.strength++;
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "1";
    }
}
