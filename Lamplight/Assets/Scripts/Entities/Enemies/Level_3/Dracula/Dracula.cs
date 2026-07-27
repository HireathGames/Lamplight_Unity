using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dracula : Enemy
{

    private void Update()
    {

    }
    private void Awake()
    {
        addMove(new EnemyAttack(15));
        addMove(new EnemyDefend(15));
        addMove(new EnemyVampireDrink(5, 7, 2));
        int startHealth = 666;
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
