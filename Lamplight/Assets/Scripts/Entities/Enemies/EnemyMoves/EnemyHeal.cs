using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal : EnemyMove
{
    private int health;
    public EnemyHeal(int heal, int anim) : base("Buff", anim)
    {
        health = heal;
    }
    public override void performMove(Enemy self, Player player)
    {
        self.setHealth(self.getHealth() + health);
        if (self.getHealth() > self.getMaxHealth())
        {
            self.setHealth(self.getMaxHealth());
        }
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return health.ToString();
    }
}
