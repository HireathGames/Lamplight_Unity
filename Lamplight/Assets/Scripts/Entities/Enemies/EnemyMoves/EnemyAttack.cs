using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyMove
{
    private int healthDamage;
    private float sanityDamage;
    public EnemyAttack(int damage) : base("Attack")
    {
        healthDamage = damage;
        sanityDamage = 0;
    }
    public EnemyAttack(int damage, float sanity) : base("Attack")
    {
        healthDamage = damage;
        sanityDamage = sanity;
    }
    public EnemyAttack(int damage, float sanity, int anim) : base("Attack", anim)
    {
        healthDamage = damage;
        sanityDamage = sanity;
    }
    public EnemyAttack(int damage, float sanity, string icon) : base(icon)
    {
        healthDamage = damage;
        sanityDamage = sanity;
    }
    public EnemyAttack(int damage, float sanity, string icon, int anim) : base(icon, anim)
    {
        healthDamage = damage;
        sanityDamage = sanity;
    }
    public override void performMove(Enemy self, Player player)
    {
        self.attackEntity(player, healthDamage, sanityDamage);
    }
}
