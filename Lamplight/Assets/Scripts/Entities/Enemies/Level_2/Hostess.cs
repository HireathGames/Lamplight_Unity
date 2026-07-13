using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostess : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyDefend(10));
        addMove(new EnemyAttack(10));
        addMove(new EnemyBleedAllPowerGain(3, 3));
        addMove(new EnemyAddStatusCard(new RedDeath(), 2, 2));
        int startHealth = Random.Range(45, 61);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'w')
        {
            mark++;
        }
    }
}
