using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glutton : Enemy
{
    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(10, 0, "Attack"));
        addMove(new EnemyAttack(7, 10, "AttackDebuff"));
        addMove(new EnemyGainStrength(2, 5, 2));
        addMove(new EnemyHeal(15, 2));
        int startHealth = Random.Range(48, 60);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'w')
        {
            bleed += 3;
            strength++;
        }
    }
}
