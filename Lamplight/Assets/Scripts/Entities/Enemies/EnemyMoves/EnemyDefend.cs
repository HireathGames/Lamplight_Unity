using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefend : EnemyMove
{
    private int defence;
    public EnemyDefend(int armor) : base("Block", 2)
    {
        defence = armor;
    }
    public override void performMove(Enemy self, Player player)
    {
        self.addArmor(defence);
    }
    public override string getMoveText(Enemy self, Player player)
    {
        if (self.broken == 0)
        {
            return defence.ToString();
        }
        else
        {
            return 0.ToString();
        }
    }
}
