using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobby : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(10));
        addMove(new EnemyDefend(10));
        addMove(new EnemyAddMark(1, 3));
        int startHealth = Random.Range(30, 45);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 't')
        {
            bleed++;
            critEffects(element);
        }
    }
}
