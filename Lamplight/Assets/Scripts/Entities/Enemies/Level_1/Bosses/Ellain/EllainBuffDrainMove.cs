using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EllainBuffDrainMove : EnemyMove
{
    public EllainBuffDrainMove() : base("AttackBuff", 1) { }
    public override void performMove(Enemy self, Player player)
    {
        self.attackEntity(player, 0, 20, 'm');
        player.weakness++;
        List<Enemy> enemies = self.GetComponent<Ellain>().getSummons();
        foreach (Enemy e in enemies)
        {
            e.strength++;
        }
    }
}
