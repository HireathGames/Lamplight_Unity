using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattle : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(7));
        addMove(new EnemyDefend(10));
        addMove(new EnemyAttack(7));
        addMove(new EnemyDefend(10));
        addMove(new EnemyAddWeakness(1));
        int startHealth = Random.Range(35, 42);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'm')
        {
            bleed += 3;
            critEffects(element);
        }
    }
}
