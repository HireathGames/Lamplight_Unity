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
}
