using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBleedAllPowerGain : EnemyMove
{
    private int bleed;
    private int power = 2;
    public EnemyBleedAllPowerGain(int blood) : base("Buff")
    {
        bleed = blood;
    }
    public EnemyBleedAllPowerGain(int blood, int anim) : base("Buff", anim)
    {
        bleed = blood;
    }
    public EnemyBleedAllPowerGain(int blood, int str, int anim) : base("BlockBuff", anim)
    {
        bleed = blood;
        power = str;
    }
    public override void performMove(Enemy self, Player player)
    {
        foreach (Enemy enemy in self.getManager().getEnemies())
        {
            enemy.bleed += bleed;
            self.strength += power;
        }
        self.healthBar.updateUI(self);
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return "???";
    }
}
