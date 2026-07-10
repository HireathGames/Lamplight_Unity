using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGiveAllStrength : EnemyMove
{
    private int strength;
    private int block = 0;
    public EnemyGiveAllStrength(int str) : base("Buff")
    {
        strength = str;
    }
    public EnemyGiveAllStrength(int str, int anim) : base("Buff", anim)
    {
        strength = str;
    }
    public EnemyGiveAllStrength(int str, int blo, int anim) : base("BlockBuff", anim)
    {
        strength = str;
        block = blo;
    }
    public override void performMove(Enemy self, Player player)
    {
        foreach (Enemy enemy in self.getManager().getEnemies())
        {
            enemy.strength += strength;
            enemy.addArmor(block);
        }
        self.healthBar.updateUI(self);
    }
}
