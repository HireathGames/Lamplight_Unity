using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : Enemy
{
    public bool happy;
    private void Awake()
    {
        if (happy)
        {
            addMove(new EnemyAttack(6));
            addMove(new EnemyGiveAllStrength(1, 10, 3));
            int startHealth = Random.Range(35, 42);
            getAnimator().SetBool("Happy", true);
            setHealth(startHealth);
            setMaxHealth(startHealth);
        }
        else
        {
            addMove(new EnemyDefendAndDrain(10, 10, 2));
            addMove(new EnemyAddWeakness(3, 3));
            int startHealth = Random.Range(45, 52);
            getAnimator().SetBool("Happy", false);
            setHealth(startHealth);
            setMaxHealth(startHealth);
        }
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (happy)
        {
            if (element == 'b')
            {
                strength = 0;
                critEffects(element);
            }
        }
        else
        {
            if (element == 'm')
            {
                foreach (Enemy enemy in getManager().getEnemies())
                {
                    enemy.weakness++;
                }
                critEffects(element);
            }
        }
    }
}
