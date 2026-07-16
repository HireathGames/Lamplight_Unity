using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infected : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyDefend(5));
        addMove(new EnemyAddBleed(2, 3));
        addMove(new EnemyDefendAndDrain(12, 5, 2));
        addMove(new EnemyAddStatusCard(new RedDeath(), 1, 3));
        int startHealth = Random.Range(25, 41);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'w')
        {
            mark++;
            critEffects(element);
        }
    }
}
