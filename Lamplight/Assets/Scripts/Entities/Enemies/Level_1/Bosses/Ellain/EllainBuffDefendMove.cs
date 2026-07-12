using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EllainBuffDefendMove : EnemyMove
{
    public EllainBuffDefendMove() : base("BlockBuff", 2) { }
    public override void performMove(Enemy self, Player player)
    {
        self.addArmor(10);
        List<Enemy> enemies = self.GetComponent<Ellain>().getSummons();
        foreach (Enemy e in enemies)
        {
            e.strength++;
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "10";
    }
}
