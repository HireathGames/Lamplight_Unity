using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGiveAllSArmor : EnemyMove
{
    private int block;
    public EnemyGiveAllSArmor(int blo) : base("Block", 2)
    {
        block = blo;
    }
    public EnemyGiveAllSArmor(int blo, int anim) : base("Block", anim)
    {
        block = blo;
    }
    public override void performMove(Enemy self, Player player)
    {
        foreach (Enemy enemy in self.getManager().getEnemies())
        {
            enemy.addArmor(block);
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return block.ToString();
    }
}
