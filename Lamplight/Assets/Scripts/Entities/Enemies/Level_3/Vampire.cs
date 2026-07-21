using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Enemy
{

    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(10));
        addMove(new EnemyDefend(10));
        addMove(new EnemyVampireDrink(3, 5, 2));
        int startHealth = Random.Range(75, 85);
        setHealth(startHealth);
        setMaxHealth(startHealth);
    }
    public override void takeDamage(int healthDamage, float sanityDamage, char element)
    {
        base.takeDamage(healthDamage, sanityDamage, element);
        if (element == 'b')
        {
            weakness++;
            critEffects(element);
        }
    }
}
