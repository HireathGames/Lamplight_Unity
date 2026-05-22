using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyMove
{
    private int healthDamage;
    private float sanityDamage;
    public EnemyAttack(int damage)
    {
        healthDamage = damage;
        sanityDamage = 0;
    }
    public EnemyAttack(int damage, float sanity)
    {
        healthDamage = damage;
        sanityDamage = sanity;
    }
    public override void performMove(Enemy self, Player player)
    {
        self.attackEntity(player, healthDamage, sanityDamage);
    }
}
