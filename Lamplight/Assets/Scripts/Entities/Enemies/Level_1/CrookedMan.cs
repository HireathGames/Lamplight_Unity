using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrookedMan : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(15, 0, "Attack"));
        addMove(new EnemyDefendAndDrain(15, 20, 2));
        addMove(new EnemyAddBroken(8, 2));
        addMove(new EnemyAddStatusCard(new Crooked(), 1, 2));
        int startHealth = Random.Range(65, 90);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 't')
        {
            broken += 3;
        }
    }
}
