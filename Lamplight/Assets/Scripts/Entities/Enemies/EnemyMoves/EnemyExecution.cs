using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExecution : EnemyMove
{
    private int healthDamage;
    private int scaling;
    public EnemyExecution(int damage) : base("Attack")
    {
        healthDamage = damage;
        scaling = 1;
    }
    public EnemyExecution(int damage, int scale) : base("Attack")
    {
        healthDamage = damage;
        scaling = scale;
    }
    public EnemyExecution(int damage, int scale, int anim) : base("Attack", anim)
    {
        healthDamage = damage;
        scaling = scale;
    }

    public override void performMove(Enemy self, Player player)
    {
        int finalCalc = healthDamage + (player.mark * scaling);
        self.attackEntity(player, finalCalc, 0, 't');
    }
    public override string getMoveText(Enemy self, Player player)
    {
        return self.damageAgainst(player, healthDamage + (player.mark * scaling)).ToString();
    }
}
